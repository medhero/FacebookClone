using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    public class ProfileVM
    {
        public Post post { get; set; }
        public List<Post> ListPosts { get; set; }
        public List<Comment> ListComments { get; set; }

        public List<User> ListUsers { get; set; }
        public User user { get; set; }
       
       
       
    }
}