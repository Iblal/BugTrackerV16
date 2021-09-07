using BugTracker.Services.Interfaces;
using BugTrackerV16.Data;
using BugTrackerV16.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerV16.Services
{
    public class BTProjectService : IBTProjectService 
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<BugTrackerV16User> _userManager;




        public BTProjectService(ApplicationDbContext context, UserManager<BugTrackerV16User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        
        public bool AddProjectUser(int projectId, string userId)
        {
              
            ProjectUser projectUser = new ProjectUser { ProjectID = projectId, UserID = userId};   

            var addProjectUser = _context.ProjectUsers.Add(projectUser);

            if (addProjectUser != null)
            {
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }


        public List<BugTrackerV16User> GetUsersAssignedToProject(int projectId)
        {
            List<BugTrackerV16User> AssignedProjectUsers = new List<BugTrackerV16User>();

            var AssignedProjectUserIds = _context.ProjectUsers
                .Where(project => project.ProjectID == projectId)
                .Select(project => project.UserID)
                .ToList();

        
            foreach(var userid in AssignedProjectUserIds)
            {

               var user = _context.Users
                    .Where(user => user.Id == userid)
                    .FirstOrDefault();

                AssignedProjectUsers.Add(user);
            } 

            return AssignedProjectUsers;
        }

        public List<BugTrackerV16User> GetUsersNotAssignedToProject(int projectId)
        {
            List<BugTrackerV16User> UnAssignedUsers = new List<BugTrackerV16User>();

            var AllUserIds = _userManager.Users
                .Select(user => user.Id)
                .ToList();

            var AssignedUserIds = _context.ProjectUsers
                .Where(project => project.ProjectID == projectId)
                .Select(project => project.UserID)
                .ToList();

            var UnAssignedUserIds = AllUserIds.Except(AssignedUserIds);

            foreach (var userId in UnAssignedUserIds)
            {
                
                var user = _context.Users
                     .Where(user => user.Id == userId)
                     .FirstOrDefault();

                UnAssignedUsers.Add(user);
            }

            return UnAssignedUsers;

        }

        
        public bool RemoveProjectUser(int projectId, string userId)
        {
            var projectUser = _context.ProjectUsers
                .Where(ProjectUser => ProjectUser.UserID == userId && ProjectUser.ProjectID == projectId)
                .FirstOrDefault();

            var removedProjectUser = _context.ProjectUsers.Remove(projectUser);

            if (removedProjectUser != null)
            {
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Project GetProject(int projectId)
        {
            var project = _context.Projects
                .Where(project => project.Id == projectId)
                .FirstOrDefault();

            return project;
        }
    }
   
}

