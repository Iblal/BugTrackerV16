using BugTrackerV16.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerV16.Models
{
    public class AssignUsers
     {
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        public int ProjectId { get; set; }
        public List<BugTrackerV16User> UsersAssignedtoProject { get; set; }
        public List<BugTrackerV16User> UsersNotAssignedToProject { get; set; }
        public string UserToAddId { get; set; }
        public string UserToRemoveId { get; set; }

    }
}
