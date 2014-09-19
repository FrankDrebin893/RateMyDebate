using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RateMyDebate.Models
{
    public class Message
    {
        [Key]
        public int messageId { get; set; }

        [ForeignKey("userInformation")]
        public int userId { get; set; }
        public virtual UserInformation userInformation { get; set; }

        [ForeignKey("inboxId")]
        public int inboxKey { get; set; }

        public Inbox inboxId { get; set; }

        
        public String Sender { get; set; }

        [Required]
        public String Receiver { get; set; }
        [Required]
        public String  subject  { get; set; }
        [Required]
        public String messageText { get; set; }
    }
}