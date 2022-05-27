using FacebookClone.Models;

using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacebookClone.Controllers
{
    public class ProfileVMController : Controller

    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult ProfileViewModel()
        {
            var id = User.Identity.GetUserId();
            var users = db.Users.Where(u => u.Id != id).ToList();
            var user= db.Users.Where(u => u.Id == id).FirstOrDefault();
            var posts = db.Posts.Where(p => p.UserId == id).ToList();
            var comments = db.Comments.ToList();
            ProfileVM mymodel = new ProfileVM();
            mymodel.ListUsers = users;
            mymodel.ListPosts = posts;
            mymodel.ListComments = comments;
            mymodel.user = user;

            return View(mymodel);
        }
        public ActionResult Like(int id)
        {
            Post update = db.Posts.ToList().Find(u => u.PostId == id);
            update.Post_like += 1;
            db.SaveChanges();
            return RedirectToAction("ProfileViewModel");
        }
        // GET: ProfileMV
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProfileMV/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfileMV/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfileMV/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfileMV/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfileMV/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfileMV/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfileMV/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
