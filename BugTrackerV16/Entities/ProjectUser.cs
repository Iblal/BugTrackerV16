using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerV16.Entities
{
    public class ProjectUser
    {
        [Key]

        [Column("Id")]
        public int Id { get; set; }

        [Column("ProjectId")]
        public int ProjectID { get; set; }

        [Column("UserId")]
        public string UserID { get; set; }

        [Column("UserRole")]
        public string UserRole { get; set; }
    }
}
