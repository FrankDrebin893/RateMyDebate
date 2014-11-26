using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RateMyDebate.Models
{
    public class Debate
    {
        public int CreatorIdId { get; set; }
        public int? ChallengerIdId { get; set; }
        public int CategoryIdId { get; set; }

        public int? WinnerId { get; set; }

        [Key]
        public int DebateId { get; set; }
        [Display(Name = "Topic")]
        public String Subject { get; set; }
        [Display (Name = "Case")]
        public String Description { get; set; }
        public String ChatText { get; set; }

        [ForeignKey("CreatorIdId")]
        public UserInformation CreatorId { get; set; }

        [ForeignKey("ChallengerIdId")]
        public UserInformation ChallengerId { get; set; }

        [ForeignKey("CategoryIdId")]
        public Category CategoryId { get; set; }
        public Boolean Draw { get; set; }

        public Boolean Live { get; set; }
        [Display (Name = "Created")]
        public DateTime DateTime { get; set; }

        public int TimeLimit { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        
    }
}