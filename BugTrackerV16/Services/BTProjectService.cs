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

        public bool AddProjectUser(int projectId, string userId)
        {
            ProjectUser projectUser = new ProjectUser { UserID = userId, ProjectID = projectId };
            
            var addedProjectUser = _context.ProjectUsers.Add(projectUser);

            if(addedProjectUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }

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
            List<BugTrackerV16User> AssignedProjectUsers = new List<BugTrackerV16User>();
            List<BugTrackerV16User> UnAssignedProjectUsers = new List<BugTrackerV16User>();
            List<BugTrackerV16User> AllUsers = new List<BugTrackerV16User>();

            AllUsers = _userManager.Users.ToList();

            AssignedProjectUsers = GetAssignedProjectUsers(projectId);

            UnAssignedProjectUsers = (List<BugTrackerV16User>)AllUsers.Except(AssignedProjectUsers);

            return UnAssignedProjectUsers;

        }

        public List<BugTrackerV16User> GetUsersInRole(string roleName)
        {
            List<BugTrackerV16User> UsersInRole = new List<BugTrackerV16User>();

            var RoleId = _context.Roles
                .Where(r => r.Name == roleName)
                .Select(r => r.Id)
                .ToString();

            var UserRoleList = _context.UserRoles
                .Where(ur => ur.RoleId == RoleId)
                .Select(ur => ur.UserId)
                .ToList();

            foreach (var userid in UserRoleList)
            {
                var projectUser = _context.Users
                     .Where(user => user.Id == userid)
                     .Select(user => user)
                     .ToList();

                UsersInRole.Add(projectUser[0]);

            }


            return UsersInRole;
        }

        public bool RemoveProjectUser(int projectId, string userId)
        {
            ProjectUser projectUser = new ProjectUser { UserID = userId, ProjectID = projectId };

            var removedProjectUser = _context.ProjectUsers.Remove(projectUser);

            if (removedProjectUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
   
}

