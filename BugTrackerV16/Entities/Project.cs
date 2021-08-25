using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerV16.Entities
{
    public class Project
    {
        [Key]

        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("CreatedDate")]
        public string CreatedDate { get; set; }

        [Column("ProjectManagerUserId")]
        public string ProjectManagerUserId { get; set; }

        [Column("ProjectManagerName")]
        public string ProjectManagerName { get; set; }

        [NotMapped]
        public virtual ICollection<BugTrackerV16User> Members { get; set; } = new HashSet<BugTrackerV16User>();
       
        [NotMapped]
        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();

    }
}
