using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        public int ID { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
        // public Comment ParentId { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime ModifiedOn { get; set; }
    }
}