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

        [Column("ReportedByUser")]
        public string ReportedByUser { get; set; }

        [Column("AssignedToUser")]
        public string AssignedToUser { get; set; }

        [Column("Status")]
        public string Status { get; set; }

        [Column("ProjectName")]
        public string ProjectName { get; set; }

        [Column("ProjectId")]
        public int ProjectId { get; set; }

        [Column("CreatedDate")]
        public string CreatedDate { get; set; }

        [Column("Priority")]
        public string Priority { get; set; }

        [Column("DateUpdated")]
        public DateTime DateUpdated { get; set; }

        [Column("Type")]
        public string Type { get; set; }

        [NotMapped]
        public List<TicketComment> TicketComments { get; set; }

    }
}
