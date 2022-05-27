using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace FacebookClone.Models
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }
        
        public string UserId { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
        public string FilePath{ get; set; }
        
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
       
        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn  { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime ModifiedOn  { get; set; }
        public int Post_like { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
/*
        public Post()
        {
            FilePath = "~/App_Files/Images/default.jpg"; 
        }*/
    }
}