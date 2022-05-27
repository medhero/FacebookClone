using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    [Table("Friend")]
    public class Friend
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RequestId { get; set; }
        public string RecieverID { get; set; }
        public User Reciever { get; set; }
        public string SenderId { get; set; }
        public User Sender { get; set; }
        public bool IsAccepted { get; set; }

    }
}