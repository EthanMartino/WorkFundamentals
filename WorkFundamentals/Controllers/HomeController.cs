using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WorkFundamentals.Data;
using WorkFundamentals.Models;

namespace WorkFundamentals.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null && userId != String.Empty)
            {
                IdentityUser currUser = await _userManager.FindByIdAsync(userId);
                await _userManager.AddToRoleAsync(currUser, IdentityHelper.Employer);
                if (await _userManager.IsInRoleAsync(currUser, IdentityHelper.Employer))
                {
                    ViewBag.IsEmployer = true;
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Send()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Send(SendSms sendSms)
        {
            sendSms.Send();
            string result = sendSms.Send();
            var deserializedObject = JsonConvert.DeserializeObject(result);

            Console.WriteLine(deserializedObject);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
