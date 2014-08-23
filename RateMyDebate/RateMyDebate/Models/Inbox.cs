using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RateMyDebate.Models
{
    public class Inbox
    {
        [Key]
        public int inboxId { get; set; }
        
        public virtual UserInformation userInformationId { get; set; }
        
        

    }
}