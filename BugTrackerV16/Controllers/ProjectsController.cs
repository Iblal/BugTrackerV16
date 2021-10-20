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
using System.Security.Claims;

namespace BugTrackerV16.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<BugTrackerV16User> _userManager;
        private readonly IBTHelperService _BTHelperService;
        private readonly IBTProjectService _projectService;


        public ProjectsController(ApplicationDbContext context, UserManager<BugTrackerV16User> userManager, IBTHelperService BTHelperService, IBTProjectService ProjectService)
        {
            _context = context;
            _userManager = userManager;
            _BTHelperService = BTHelperService;
            _projectService = ProjectService;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            return View(await _context.Projects.ToListAsync());
        }

        public async Task<IActionResult> ArchivedProjectsIndex()
        {
            var archivedProjects = await _context.Projects
                .Where(project => project.Archived == true)
                .ToListAsync();

            return View(archivedProjects);
        }

        public IActionResult ArchiveProject(int projectId)
        {

            var project = _projectService.GetProject(projectId);

            return View(@"\Views\Projects\ArchiveConfirm.cshtml", project);

        }

        public IActionResult ArchiveConfirm(int projectId)
        {
            
            var projectEntity = _context.Projects.First(project => project.Id == projectId);
            projectEntity.Archived = true;
            _context.SaveChanges();


            return RedirectToAction("myProjectsIndex");

        }

        public async Task<IActionResult> myProjectsIndex()
        {
            List<Project> UserProjects = new List<Project>();

            var userId = _userManager.GetUserId(User);

            var UserProjectIds = _context.ProjectUsers
                .Where(projectuser => projectuser.UserID == userId)
                .Select(projectuser => projectuser.ProjectID)
                .ToListAsync();

            foreach (var projectId in await UserProjectIds)
            {

                var project = _context.Projects
                     .Where(project => project.Id == projectId)
                     .FirstOrDefault();

                if(project != null)
                {
                    UserProjects.Add(project);
                }
               
            }

            return View(UserProjects);
        }



        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            

            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,CreatedDate,ProjectManagerUserId,ProjectManagerName")] Project project)
        {
            DateTime currentDateTime = DateTime.Now;

            project.CreatedDate = currentDateTime.ToString();

            project.ProjectManagerUserId = _userManager.GetUserId(User);

            project.ProjectManagerName = User.Identity.Name;

            


            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();

                _projectService.AddProjectUser(project.Id, project.ProjectManagerUserId);

                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CreatedDate,ProjectManagerUserId")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(project.Name != null)
                    {

                        var projectEntity = _context.Projects.First(project => project.Id == id);
                        projectEntity.Name = project.Name;
                        _context.SaveChanges();

                    }
                    
                    if(project.Description != null)
                    {
                        var projectEntity = _context.Projects.First(project => project.Id == id);
                        projectEntity.Description = project.Description;
                        _context.SaveChanges();
                    }

                    
                    
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .FirstOrDefaultAsync(m => m.Id == id);


            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var project = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(project);

            var projectUsers = _context.ProjectUsers
                .Where(projectUser => projectUser.ProjectID == id)
                .ToList();
            _context.ProjectUsers.RemoveRange(projectUsers);

            var projectTickets = _context.Tickets
                .Where(ticket => ticket.ProjectId == id)
                .ToList();
            _context.Tickets.RemoveRange(projectTickets);


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
