using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RateMyDebate.Models
{
    public class Debate
    {
        [Key]
        public int DebateId { get; set; }
        public String Subject { get; set; }
        public String Description { get; set; }
        public String ChatText { get; set; }
        public UserInformation CreatorId { get; set; }
        public UserInformation ChallengerId { get; set; }

        public Category CategoryId { get; set; }

        public int CreatorVotes { get; set; }
        public int ChallengerVotes { get; set; }

       // public List<UserInformation> PassiveSpectatorsIdList { get; set; }
        //public List<UserInformation> CreatorSpectatorsIdList { get; set; }
        //public List<UserInformation> ChallengerSpectatorsIdList { get; set; }

        public Boolean Live { get; set; }
        public DateTime DateTime { get; set; }
    }
}