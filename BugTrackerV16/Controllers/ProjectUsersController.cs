using BugTracker.Services.Interfaces;
using BugTrackerV16.Models;
using BugTrackerV16.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerV16.Controllers
{
    public class ProjectUsersController : Controller
    {
        private IBTProjectService _btProjectService;

        public ProjectUsersController(IBTProjectService btProjectService)
        {
            _btProjectService = btProjectService;
        }

       
        public IActionResult AssignUsers(int projectId)
        {
            
                AssignUsers assignUsers = new AssignUsers();

                assignUsers.ProjectId = _btProjectService.GetProject(projectId).Id;
                assignUsers.ProjectName = _btProjectService.GetProject(projectId).Name;
                assignUsers.UsersAssignedtoProject = _btProjectService.GetUsersAssignedToProject(projectId);
                assignUsers.UsersNotAssignedToProject = _btProjectService.GetUsersNotAssignedToProject(projectId);

              return View(assignUsers);
        }


        [HttpPost]
        public IActionResult AddUserToProject(AssignUsers model)
        {
            _btProjectService.AddProjectUser(model.ProjectId, model.UserToAddId);
                

            return RedirectToAction("AssignUsers", new { projectId = model.ProjectId });
        }

        [HttpPost]
        public IActionResult RemoveUserFromProject(AssignUsers model)
        {
            _btProjectService.RemoveProjectUser(model.ProjectId, model.UserToRemoveId);

            return RedirectToAction("AssignUsers", new { projectId = model.ProjectId });
        }
    }
}
