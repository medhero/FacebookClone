using FacebookClone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacebookClone.Controllers
{
    public class FiendVMController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: HomeVM
        [Authorize]
        public ActionResult Index()
        {
            var Friendlist = db.Friends.Select(x=>x.RecieverID).ToList();
            var id = User.Identity.GetUserId();
           // var users = db.Users.Where();

            var posts = db.Posts.ToList();
            var comments = db.Comments.ToList();
            var Invites = db.Friends.Where(f => f.IsAccepted == false).ToList();
            FriendRVM mymodel = new FriendRVM
            {
               
                //Users = users


            };

            return View(mymodel);
        }
    }
}