using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerV16.Models
{
    public class AssignUsersModel
     {
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        public int ProjectId { get; set; }
        public MultiSelectList UsersAssignedtoProject { get; set; }
        public MultiSelectList UsersNotAssignedToProject { get; set; }
        public string[] UsersToAdd { get; set; }
        public string[] UsersToRemove { get; set; }
    }
}
