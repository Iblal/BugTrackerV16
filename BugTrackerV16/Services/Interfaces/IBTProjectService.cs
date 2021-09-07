﻿using BugTrackerV16.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Services.Interfaces
{
    public interface IBTProjectService
    {
        public Project GetProject(int projectId);
        public List<BugTrackerV16User> GetUsersAssignedToProject(int projectId);
        public List<BugTrackerV16User> GetUsersNotAssignedToProject(int projectId);
        public bool AddProjectUser(int projectId, string userId);
        public bool RemoveProjectUser(int projectId, string userId);

    }
}
