using BugTrackerV16.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Services.Interfaces
{
    public interface IBTProjectService
    {
        public BugTrackerV16User GetProjectManager(string projectManagerUserId);
        public List<BugTrackerV16User> GetAssignedProjectUsers(int projectId);
        public List<BugTrackerV16User> GetUnAssignedProjectUsers(int projectId);
        public ProjectUser AddProjectUser(int projectId, string userId);
        public ProjectUser RemoveProjectUser(int projectId, string userId);

    }
}
