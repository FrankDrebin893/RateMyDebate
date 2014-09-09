using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RateMyDebate.Models
{
    public class Debate
    {
        public int CreatorIdId { get; set; }
        public int ChallengerIdId { get; set; }
        public int CategoryIdId { get; set; }

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

        [Display (Name = "Creator votes")]
        public int CreatorVotes { get; set; }

        [Display (Name = "Challenger votes")]
        public int ChallengerVotes { get; set; }

       // public List<UserInformation> PassiveSpectatorsIdList { get; set; }
        //public List<UserInformation> CreatorSpectatorsIdList { get; set; }
        //public List<UserInformation> ChallengerSpectatorsIdList { get; set; }

        public Boolean Live { get; set; }
        [Display (Name = "Created")]
        public DateTime DateTime { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}