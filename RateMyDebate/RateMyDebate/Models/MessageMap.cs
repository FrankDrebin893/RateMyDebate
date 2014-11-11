using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RateMyDebate.Models
{
    public class MessageMap
    {
        public int InboxId { get; set; }


        [Key, Column(Order = 1)]
        public int MessageId { get; set; }

        [Key, Column(Order = 2)]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserInformation User { get; set; }

        [ForeignKey("MessageId")]
        public Message Message { get; set; }

        [ForeignKey("InboxId")]
        public Inbox Inbox { get; set; }

        public Boolean IsRead { get; set; }
    }
}