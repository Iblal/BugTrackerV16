using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerV16.Entities
{
    public class TicketComment
    {

        [Key]

        [Column("Id")]
        public int Id { get; set; }

        [Column("TicketId")]
        public int TicketId { get; set; }

        [Column("Comment")]
        public string Comment { get; set; }

        [Column("CreatedDate")]
        public string CreatedDate { get; set; }

        [Column("CommentUserId")]
        public string CommentUserId { get; set; }



    }
}
