using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FacebookClone.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace FacebookClone.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Posts
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,Content,ImageFile,CreatedOn,ModifiedOn,Post_like")] Post post)
        {
            if (ModelState.IsValid)
            {

                post.UserId = User.Identity.GetUserId();
                post.Post_like = 0;
                post.CreatedOn = DateTime.Now;
                post.ModifiedOn = DateTime.Now;

                if(post.ImageFile!= null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(post.ImageFile.FileName);
                    string extension = Path.GetExtension(post.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    post.FilePath = "~/App_Files/Images/" + fileName;
                    post.ImageFile.SaveAs(Path.Combine(Server.MapPath("~/App_Files/Images/"), fileName));

                }
                else
                {
                    //post.FilePath = "data:image/svg+xml;charset=UTF-8,%3Csvg%20width%3D%22286%22%20height%3D%22180%22%20xmlns%3D%22http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg%22%20viewBox%3D%220%200%20286%20180%22%20preserveAspectRatio%3D%22none%22%3E%3Cdefs%3E%3Cstyle%20type%3D%22text%2Fcss%22%3E%23holder_166c854be1e%20text%20%7B%20fill%3Argba(255%2C255%2C255%2C.75)%3Bfont-weight%3Anormal%3Bfont-family%3AHelvetica%2C%20monospace%3Bfont-size%3A14pt%20%7D%20%3C%2Fstyle%3E%3C%2Fdefs%3E%3Cg%20id%3D%22holder_166c854be1e%22%3E%3Crect%20width%3D%22286%22%20height%3D%22180%22%20fill%3D%22%23777%22%3E%3C%2Frect%3E%3Cg%3E%3Ctext%20x%3D%2299.125%22%20y%3D%2296.3%22%3EImage%20Post%3C%2Ftext%3E%3C%2Fg%3E%3C%2Fg%3E%3C%2Fsvg%3E";

                    post.FilePath = " ";              
                }
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index","HomeVM");
            }

            return View(post);
        }

        public ActionResult Like(int id)
        {
            Post update = db.Posts.ToList().Find(u => u.PostId == id);
            update.Post_like += 1;
            db.SaveChanges();
            return RedirectToAction("Index", "HomeVM");
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



        public ActionResult AddFriend(string id)
        {
            Friend friend = new Friend();
            friend.SenderId = User.Identity.GetUserId();
            friend.RecieverID = id;
            db.Friends.Add(friend);
            db.SaveChanges();
            return RedirectToAction("Index", "HomeVM");
        }

            // GET: Posts/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Post post = db.Posts.Find(id);
                if (post == null)
                {
                    return HttpNotFound();
                }
                return View(post);
            }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostId,Content,FileName,FileExtension,CreatedOn,ModifiedOn,Post_like")] Post post)
        {
            
            var Updatedpost = db.Posts.Where(p => p.PostId == post.PostId).FirstOrDefault();
            
            Updatedpost.Content = post.Content;
            Updatedpost.CreatedOn = DateTime.Now;
            Updatedpost.ModifiedOn = DateTime.Now;

            if (Updatedpost.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(Updatedpost.ImageFile.FileName);
                string extension = Path.GetExtension(Updatedpost.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                Updatedpost.FilePath = "~/App_Files/Images/" + fileName;
                Updatedpost.ImageFile.SaveAs(Path.Combine(Server.MapPath("~/App_Files/Images/"), fileName));

            }
            else
            {
                Updatedpost.FilePath = " ";
            }
           
            if (ModelState.IsValid)
            {

                db.Entry(Updatedpost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "HomeVM");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index","HomeVM");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
