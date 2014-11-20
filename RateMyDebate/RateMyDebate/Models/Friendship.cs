using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RateMyDebate.Models
{
    public class Friendship
    {
        [Key]
        public int FriendshipId { get; set; }
        public int FriendOneId { get; set; }
        public int FriendTwoId { get; set; }

        [ForeignKey("FriendOneId")]
        public UserInformation FriendOne { get; set; }
        [ForeignKey("FriendTwoId")]
        public UserInformation FriendTwo { get; set; }

        public DateTime Since { get; set; }
        public Boolean Accepted { get; set; }
    }
}