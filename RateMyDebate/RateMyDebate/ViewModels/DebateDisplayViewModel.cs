using System.Collections.Generic;
using RateMyDebate.Models;

namespace RateMyDebate.ViewModels
{
    public class DebateDisplayViewModel
    {
        public Debate Debate { get; set; }
        public List<UserInformation> CreatorInformation { get; set; }
        public List<UserInformation> ChallengerInformation { get; set; }
        public List<Category> Category { get; set; }
    }
}