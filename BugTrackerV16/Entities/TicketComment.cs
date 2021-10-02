using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerV16.Entities
{
    public class TicketComment
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Comment { get; set; }
        public string CreatedDate { get; set; }

    }
}
