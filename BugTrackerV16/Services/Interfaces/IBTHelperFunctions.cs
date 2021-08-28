using BugTrackerV16.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerV16.Services.Interfaces
{
    interface IBTHelperFunctions
    {
        public List<BugTrackerV16User> GetUsersInRole(string roleName);
        public BugTrackerV16User GetUser(string UserId);
    }
}
