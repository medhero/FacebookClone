using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FacebookClone.Models;
using Microsoft.AspNet.Identity;

namespace FacebookClone.Controllers
{
    public class FriendsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult AddFriend(string id)
        {
            Friend friend = new Friend();
            friend.SenderId = User.Identity.GetUserId();
            friend.RecieverID = id;
            friend.IsAccepted = false;
            db.Friends.Add(friend);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        // GET: Friends
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var friends = db.Friends.Include(f => f.Reciever).Include(f => f.Sender).Where(f => f.SenderId == id && f.IsAccepted == true); 
            
            return View(friends.ToList());
        }

        public ActionResult FriendRecomendation()
        {
            var id = User.Identity.GetUserId();

            var friends = db.Users.Where(u=>u.Id!= id).ToList();

            return View(friends);
        }

        public ActionResult AcceptRequest(int id)
        {
            Friend update = db.Friends.Where(f=>f.RequestId == id).FirstOrDefault();
            update.IsAccepted = true;
            db.SaveChanges();
            return RedirectToAction("Index", "HomeVM");
        }
        public ActionResult RemoveRequest(int id)
        {
            Friend update = db.Friends.Where(f => f.RequestId == id).FirstOrDefault();
            db.Friends.Remove(update);
            db.SaveChanges();
            return RedirectToAction("Index", "HomeVM");
        }

        // GET: Friends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = db.Friends.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }


       


        // GET: Friends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = db.Friends.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        // POST: Friends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Friend friend = db.Friends.Find(id);
            db.Friends.Remove(friend);
            db.SaveChanges();
            return RedirectToAction("Index");
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
