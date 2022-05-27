using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Models.Account
{
    public class HomeViewModel
    {
        public Post post { get; set; }      
        public List<Post> posts { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Friend> Friends { get; set; }
        public List<Friend> Invites { get; set; }
        public Friend friend { get; set; }
        public List<User> Users { get; set; }
        public Comment comment { get; set; }
        public string Content { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

    }
}