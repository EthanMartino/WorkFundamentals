using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ScheduleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ViewAllSchedules()
        {
            List<Schedule> schedules = await ScheduleDb.GetAllSchedules(_context);

            return View(schedules);
        }
    }
}
