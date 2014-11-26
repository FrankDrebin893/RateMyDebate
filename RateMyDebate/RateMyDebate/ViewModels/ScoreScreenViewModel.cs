using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RateMyDebate.Models;

namespace RateMyDebate.ViewModels
{
    public class ScoreScreenViewModel
    {
        public Debate debate { get; set; }
        public Result result { get; set; }
    }
}