using BugTracker.Services.Interfaces;
using BugTrackerV16.Data;
using BugTrackerV16.Entities;
using Microsoft.AspNetCore.Identity;
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

        public ProjectUser AddProjectUser(int projectId, string userId)
        {
            throw new NotImplementedException();
        }

        public List<BugTrackerV16User> GetAssignedProjectUsers(int projectId)
        {
            List<BugTrackerV16User> AssignedProjectUsers = new List<BugTrackerV16User>();

            var AssignedProjectUserIds = _context.ProjectUsers
                .Where(project => project.Id == projectId)
                .Select(project => project.UserID)
                .ToList();


            foreach(var userid in AssignedProjectUserIds)
            {
                var projectUser = _context.Users
                     .Where(user => user.Id == userid)
                     .Select(user => user)
                     .ToList();

                AssignedProjectUsers.Add(projectUser[0]);
                
            }

            return AssignedProjectUsers;
        }

        public BugTrackerV16User GetProjectManager(string projectManagerUserId)
        {
            var projectmanager = _context.Users
                .Where(user => user.Id == projectManagerUserId)
                .ToList();

            if (projectmanager != null)
            {
                return projectmanager[0];
            }
            else
            {
                return null;
            }
        }

        public List<BugTrackerV16User> GetUnAssignedProjectUsers(int projectId)
        {
            throw new NotImplementedException();
        }

        public ProjectUser RemoveProjectUser(int projectId, string userId)
        {
            throw new NotImplementedException();
        }
    }
   
}

