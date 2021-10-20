using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BugTrackerV16.Data;
using BugTrackerV16.Entities;
using Microsoft.AspNetCore.Identity;
using BugTrackerV16.Services.Interfaces;
using X.PagedList;
using X.PagedList.Mvc;


namespace BugTrackerV16.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<BugTrackerV16User> _userManager;
        private readonly IBTHelperService _BTHelperService;
        private readonly IBTProjectService _projectService;

        public TicketsController(ApplicationDbContext context, UserManager<BugTrackerV16User> userManager, IBTHelperService BTHelperService, IBTProjectService ProjectService)
        {
            _context = context;
            _userManager = userManager;
            _BTHelperService = BTHelperService;
            _projectService = ProjectService;
        }

        public async Task<IActionResult> Index()
        {
            var allTickets = await _context.Tickets
            .ToListAsync();
            

            return View(allTickets);
        }

        public async Task<IActionResult> Dashboard()
        {
            var recentlyUpdatedTickets = await _context.Tickets
            .OrderByDescending(t => t.DateUpdated)
            .ToListAsync();

            return View(recentlyUpdatedTickets);
        }

        


        public async Task<IActionResult> myTicketsIndex()
        {
            var tickets = await _context.Tickets
                 .Where(ticket => ticket.AssignedToUser == _BTHelperService.GetUser(_userManager.GetUserId(User)).FirstName)
                 .ToListAsync();

            return View(tickets); 
                
        }

        public async Task<IActionResult> ProjectTicketsIndex(int projectId)
        {
                   
            return View(await _context.Tickets
                .Where(ticket => ticket.ProjectId == projectId)
                .ToListAsync());
            
        }



        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            ticket.TicketComments = _context.TicketComments
             .Where(ticketComment => ticketComment.TicketId == id)
             .ToList();

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ReportedByUser,AssignedToUser,Priority,Status,ProjectId,CreatedDate")] Ticket ticket)
        {

            ticket.ReportedByUser = _BTHelperService.GetUser(_userManager.GetUserId(User)).FirstName;
            
            if(ticket.AssignedToUser == "Not Assigned")
            {
                ticket.Status = "New";
            }
            else
            {
                ticket.Status = "Waiting for support";
            }

            
            ticket.ProjectName = _projectService.GetProject(ticket.ProjectId).Name;

            

            DateTime currentDateTime = DateTime.Now;
            ticket.CreatedDate = currentDateTime.ToString();

            ticket.DateUpdated = currentDateTime;

            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction("myTicketsIndex");
            }
           return RedirectToAction("myTicketsIndex");
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Type,AssignedToUser,Status,ProjectID,CreatedDate")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (ticket.Name != null)
                    {

                        var ticketEntity = _context.Tickets.First(ticket => ticket.Id == id);
                        ticketEntity.Name = ticket.Name;

                        DateTime currentDateTime = DateTime.Now;

                        ticketEntity.DateUpdated = currentDateTime;

                        _context.SaveChanges();

                    }

                    if (ticket.Description != null)
                    {
                        var ticketEntity = _context.Tickets.First(ticket => ticket.Id == id);
                        ticketEntity.Description = ticket.Description;

                        DateTime currentDateTime = DateTime.Now;

                        ticketEntity.DateUpdated = currentDateTime;

                        _context.SaveChanges();
                    }

                    if (ticket.AssignedToUser != null)
                    {
                        var ticketEntity = _context.Tickets.First(ticket => ticket.Id == id);
                        ticketEntity.AssignedToUser = ticket.AssignedToUser;

                        DateTime currentDateTime = DateTime.Now;

                        ticketEntity.DateUpdated = currentDateTime;

                        _context.SaveChanges();
                    }

                    if (ticket.Status != null)
                    {
                        var ticketEntity = _context.Tickets.First(ticket => ticket.Id == id);
                        ticketEntity.Status = ticket.Status;

                        DateTime currentDateTime = DateTime.Now;

                        ticketEntity.DateUpdated = currentDateTime;

                        _context.SaveChanges();
                    }

                    if (ticket.Type != null)
                    {
                        var ticketEntity = _context.Tickets.First(ticket => ticket.Id == id);
                        ticketEntity.Type = ticket.Type;

                        DateTime currentDateTime = DateTime.Now;

                        ticketEntity.DateUpdated = currentDateTime;

                        _context.SaveChanges();
                    }

                    if (ticket.Priority != null)
                    {
                        var ticketEntity = _context.Tickets.First(ticket => ticket.Id == id);
                        ticketEntity.Priority = ticket.Priority;

                        DateTime currentDateTime = DateTime.Now;

                        ticketEntity.DateUpdated = currentDateTime;

                        _context.SaveChanges();
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("myTicketsIndex");
            }

            return RedirectToAction("myTicketsIndex");
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction("myTicketsIndex");
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
}
