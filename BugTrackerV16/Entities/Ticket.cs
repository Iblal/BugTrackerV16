using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerV16.Entities
{
    public class Ticket
    {
        [Key]

        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("ReportedByUserId")]
        public string ReportedByUserID { get; set; }

        [Column("AssignedToUserId")]
        public string AssignedToUserID { get; set; }

        [Column("Status")]
        public string Status { get; set; }

        [Column("ProjectID")]
        public int ProjectID { get; set; }

        [Column("CreatedDate")]
        public string CreatedDate { get; set; }

    }
}
