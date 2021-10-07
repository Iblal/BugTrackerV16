using BugTrackerV16.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerV16.Services.Interfaces
{
    public interface IBTHelperService
    {
        public List<IdentityRole> GetUserRoles(BugTrackerV16User user);
        public List<BugTrackerV16User> GetUsersInRole(string roleName);
        public BugTrackerV16User GetUser(string UserId);
    }
}
