using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkFundamentals.Data;
using WorkFundamentals.Data.DbHelpers;
using WorkFundamentals.Models;

namespace WorkFundamentals.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ScheduleController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ViewAllSchedules()
        {
            List<Schedule> schedules = await ScheduleDb.GetAllSchedules(_context);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null && userId != String.Empty)
            {
                IdentityUser currUser = await _userManager.FindByIdAsync(userId);
                await _userManager.AddToRoleAsync(currUser, IdentityHelper.Employer); //Hard coded Employer for testing
                if (await _userManager.IsInRoleAsync(currUser, IdentityHelper.Employer))
                {
                    ViewBag.IsEmployer = true;
                }
            }

            return View(schedules);
        }

        [HttpGet]
        public IActionResult CreateSchedule()
        {
            return View();
        }

        [Authorize(Roles = IdentityHelper.Employer)]
        [HttpPost]
        public async Task<IActionResult> CreateSchedule(int id)
        {
            if (ScheduleDb.GetCurrentScheduleByEmployeeId(ViewBag.EmployeeId, _context) == null)
            {
                return RedirectToAction("ViewAllSchedules");
            }

            Schedule currSchedule = await ScheduleDb.GetScheduleById(id, _context);
            ScheduleDb.Add(currSchedule, _context);

            return RedirectToAction("ViewAllSchedules");
        }

        [HttpGet]
        public IActionResult AssignTask()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AssignTask(WorkTask task)
        {
            await WorkTaskDb.Add(task, _context);
            return RedirectToAction("ViewAllSchedules");
        }
    }
}
