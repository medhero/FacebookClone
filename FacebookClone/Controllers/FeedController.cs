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
    public class FeedController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
       
        // GET: Feed
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var users = db.Users.Where(u => u.Id != id).ToList();
            var post = new Post();
            var posts = db.Posts.ToList();
            var comments = db.Comments.ToList();
            dynamic mymodel = new ExpandoObject();
            mymodel.post = post; 
            mymodel.ListUsers = users;
            mymodel.ListPosts = posts;
            mymodel.ListComments = comments;

            return View(mymodel);
        }


        // GET: Feed/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Feed/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Feed/Create
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

        // GET: Feed/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Feed/Edit/5
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

        // GET: Feed/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Feed/Delete/5
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
