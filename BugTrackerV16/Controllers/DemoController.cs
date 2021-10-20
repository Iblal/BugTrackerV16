using BugTrackerV16.Data;
using BugTrackerV16.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerV16.Controllers
{
    public class DemoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<BugTrackerV16User> _userManager;
        private readonly SignInManager<BugTrackerV16User> _signInManager;


        public DemoController(ApplicationDbContext context, UserManager<BugTrackerV16User> userManager, SignInManager<BugTrackerV16User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<IActionResult> SubmitterDemoLoginAsync()
        {
            var submitterdDemoUserId = "196e16a6-71f9-4c47-93cb-f478fff03d6b";


            var SubmitterUser = _context.Users
                .Where(user => user.Id == submitterdDemoUserId)
                .FirstOrDefault();

            await _signInManager.SignInAsync(SubmitterUser, false);


            return RedirectToAction("Dashboard", "Tickets");
            
        }

         public async Task<IActionResult> ProjectManagerDemoLogin()
        {
            var projectManagerDemoUserId = "fa50df53-dbc0-46be-a9fa-e38d513ae373";


            var SubmitterUser = _context.Users
                .Where(user => user.Id == projectManagerDemoUserId)
                .FirstOrDefault();

            await _signInManager.SignInAsync(SubmitterUser, false);


            return RedirectToAction("Dashboard", "Tickets");
        }

        public async Task<IActionResult> DeveloperDemoLogin()
        {
            var developerDemoUserId = "ac5eca38-e952-4cc1-ab76-0bdc29238f54";


            var SubmitterUser = _context.Users
                .Where(user => user.Id == developerDemoUserId)
                .FirstOrDefault();

            await _signInManager.SignInAsync(SubmitterUser, false);


            return RedirectToAction("Dashboard", "Tickets");
        }

        public async Task<IActionResult> AdminDemoLogin()
        {
            var adminDemoUserId = "fa50df53-dbc0-46be-a9fa-e38d513ae373";

            var SubmitterUser = _context.Users
                .Where(user => user.Id == adminDemoUserId)
                .FirstOrDefault();

            await _signInManager.SignInAsync(SubmitterUser, false);


            return RedirectToAction("Dashboard", "Tickets");
        }

    }
}
