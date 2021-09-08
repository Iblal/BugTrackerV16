using BugTrackerV16.Data;
using BugTrackerV16.Entities;
using BugTrackerV16.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerV16.Services
{
    public class HelperFunctionsService : IBTHelperService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<BugTrackerV16User> _userManager;



        public HelperFunctionsService(ApplicationDbContext context, UserManager<BugTrackerV16User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public BugTrackerV16User GetUser(string userid)
        {
            var User = _context.Users
                .Where(user => user.Id == userid)
                .FirstOrDefault();

            return User;
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
    }
}
