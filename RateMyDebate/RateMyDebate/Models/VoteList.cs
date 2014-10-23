using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RateMyDebate.Models
{
    public class VoteList
    {
        public int VoterId { get; set; }
        public int DebateId { get; set; }

        [Key]
        public int VoteListId { get; set; }

        [ForeignKey("VoterId")]
        public UserInformation Voter { get; set; }

        [ForeignKey("DebateId")]
        public Debate Debate { get; set; }
        public int Vote { get; set; }

    }
}