using System.Collections.Generic;
using RateMyDebate.Models;

namespace RateMyDebate.ViewModels
{
    public class DebateDisplayViewModel
    {
        public Debate Debate { get; set; }
        public Category Category { get; set; }
        public UserInformation CreatorInformation { get; set; }
        public UserInformation ChallengerInformation { get; set; }
        
    }
}