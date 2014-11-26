using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RateMyDebate.Models
{
    public class Vote
    {

        [Key, Column(Order = 0)]
        public int VoterId { get; set; }

        [Key, Column(Order = 1)]
        public int DebateId { get; set; }

        [ForeignKey("VoterId")]
        public UserInformation Voter { get; set; }

        [ForeignKey("DebateId")]
        public Debate Debate { get; set; }
        public int VotePos { get; set; }
    }
}