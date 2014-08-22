using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RateMyDebate.Models
{
    public class DebateModel
    {
        public int DebatId { get; set; }
        public String Subject { get; set; }

        public String Description { get; set; }
        public String ChatText { get; set; }
        public int CreatorId { get; set; }
        public int ChallengerId { get; set; }
        public int UniqueHits { get; set; }
        public int Hits { get; set; }
        
        //public List<Account> passiveSpectators { get; set; }
        //public List<Account> creatorSpectators { get; set; }
        //public List<Account> challengerSpectators { get; set; }

        public DateTime DateTime { get; set; }
    }
}