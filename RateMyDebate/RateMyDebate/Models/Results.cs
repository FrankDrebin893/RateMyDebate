using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RateMyDebate.Models
{
    public class Result
    {


        public int WinnerId { get; set; }
        public int LoserId { get; set; }

        
        public Debate Debate { get; set; }

        [Key, ForeignKey("Debate")]
        public int DebateId { get; set; }

        [ForeignKey("WinnerId")]
        public UserInformation Winner { get; set; }

        [ForeignKey("LoserId")]
        public UserInformation Loser { get; set; }

    }
}