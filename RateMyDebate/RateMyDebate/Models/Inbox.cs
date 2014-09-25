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

        [ForeignKey("userInformation")]
        public int userId { get; set; }
        public virtual UserInformation userInformation { get; set; }


        [ForeignKey("messageId")]
        public ICollection<Message> messageId { get; set; }
        

    }
}