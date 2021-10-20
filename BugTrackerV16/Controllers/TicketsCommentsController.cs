using BugTrackerV16.Data;
using BugTrackerV16.Entities;
using BugTrackerV16.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BugTrackerV16.Controllers
{
    public class TicketsComments : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<BugTrackerV16User> _userManager;
        private readonly IBTHelperService _BTHelperService;
        private readonly IBTProjectService _projectService;

        public TicketsComments(ApplicationDbContext context, UserManager<BugTrackerV16User> userManager, IBTHelperService BTHelperService, IBTProjectService ProjectService)
        {
            _context = context;
            _userManager = userManager;
            _BTHelperService = BTHelperService;
            _projectService = ProjectService;
        }


        // GET: TicketsComments
        public ActionResult Index()
        {
            return View();
        }

        // GET: TicketsComments/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TicketsComments/Create
        public ActionResult Create(int ticketId)
        {
            var model = new TicketComment();
            model.TicketId = ticketId;
            

            return View(model);
            
        }

        // POST: TicketsComments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(include:"Id, Comment, TicketId")] TicketComment ticketComment)
         {

            ticketComment.CommentUserId = _userManager.GetUserId(User);

            DateTime currentDateTime = DateTime.Now;
            ticketComment.CreatedDate = currentDateTime.ToString();

             _context.TicketComments.Add(ticketComment);

            var ticket = _context.Tickets
                .Where(ticket => ticket.Id == ticketComment.TicketId)
                .FirstOrDefault();

            

            if (ticketComment != null)
            {
                ticket.DateUpdated = currentDateTime;

                _context.SaveChanges();
            }

            return RedirectToAction("Details", "Tickets", new { id = ticketComment.TicketId });
        }

        // GET: TicketsComments/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TicketsComments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketsComments/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TicketsComments/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
