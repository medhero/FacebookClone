using Microsoft.AspNet.Identity;
using FacebookClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FacebookClone.Models.Account;
using System.IO;

namespace FacebookClone.Controllers
{
    
    public class HomeVMController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: HomeVM
        [Authorize]
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var users = db.Users.ToList();

            var posts = db.Posts.ToList();
            var comments = db.Comments.ToList();
            var Invites =  db.Friends.Where(f=>f.IsAccepted == false).ToList();
            HomeViewModel mymodel = new HomeViewModel
            {
                posts = posts,
                Comments = comments,
                Invites = Invites,
                Users = users
                
            };

            return View(mymodel);
        }

        public ActionResult AddComment([Bind(Include = "ID,Content")] Comment comment, int PostId)
        {
            if (ModelState.IsValid)
            {
                comment.UserId = User.Identity.GetUserId();
                comment.PostId = PostId;
                comment.CreatedOn = DateTime.Now;
                comment.ModifiedOn = DateTime.Now;
                db.Comments.Add(comment);
                db.SaveChanges();

            }
            return RedirectToAction("Index", "HomeVM");
        }

        public ActionResult Comment(HomeViewModel model)
        {
            Random rnd = new Random();
            var userName = User.Identity.Name;
            var author = db.Users.SingleOrDefault(x => x.UserName == userName);

            Comment newPost = new Comment
            {
                UserId = User.Identity.GetUserId(),
                CommentId = 11,

                User = author,
                Content = model.Content,
                Post = model.post
            };


            db.Comments.Add(newPost);
            db.SaveChanges();
            return RedirectToAction("Index", "HomeVM");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,Content,ImageFile,CreatedOn,ModifiedOn,Post_like")] HomeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Post post = new Post();
                post.UserId = User.Identity.GetUserId();
                post.CreatedOn = DateTime.Now;
                post.ModifiedOn = DateTime.Now;
                post.ImageFile = model.ImageFile;
                post.Content = model.Content;

                if (post.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(post.ImageFile.FileName);
                    string extension = Path.GetExtension(post.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    post.ImageFile.SaveAs(Path.Combine(Server.MapPath("~/App_Files/Images/"), fileName));
                    post.FilePath = "~/App_Files/Images/" + fileName;

                }
                else
                {
                    //post.FilePath = "data:image/svg+xml;charset=UTF-8,%3Csvg%20width%3D%22286%22%20height%3D%22180%22%20xmlns%3D%22http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg%22%20viewBox%3D%220%200%20286%20180%22%20preserveAspectRatio%3D%22none%22%3E%3Cdefs%3E%3Cstyle%20type%3D%22text%2Fcss%22%3E%23holder_166c854be1e%20text%20%7B%20fill%3Argba(255%2C255%2C255%2C.75)%3Bfont-weight%3Anormal%3Bfont-family%3AHelvetica%2C%20monospace%3Bfont-size%3A14pt%20%7D%20%3C%2Fstyle%3E%3C%2Fdefs%3E%3Cg%20id%3D%22holder_166c854be1e%22%3E%3Crect%20width%3D%22286%22%20height%3D%22180%22%20fill%3D%22%23777%22%3E%3C%2Frect%3E%3Cg%3E%3Ctext%20x%3D%2299.125%22%20y%3D%2296.3%22%3EImage%20Post%3C%2Ftext%3E%3C%2Fg%3E%3C%2Fg%3E%3C%2Fsvg%3E";

                    post.FilePath = " ";
                }
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index", "HomeVM");
            }

            return View(model);
        }



    }
}
