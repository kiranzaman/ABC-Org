using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PRSipl.Models;

namespace PRSipl.Controllers
{
    public class UsersController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: Users
        public ActionResult Index()
        {
            if (Session["username"].ToString() == "admin")
            {
                return View(db.Users.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["username"].ToString() == "admin")
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }

            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            if (Session["username"].ToString() == "admin")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,User_Name,Password")] User user)
        {
            if (Session["username"].ToString() == "admin")
            {

                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(user);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }




        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {

            if (Session["username"].ToString() == "admin")
            {


                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }

            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,User_Name,Password")] User user)
        {
            if (Session["username"].ToString() == "admin")
            {

                if (ModelState.IsValid)
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["username"].ToString() == "admin")
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }

            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["username"].ToString() == "admin")
            {

                User user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (Session["username"].ToString() == "admin")
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }

        }
    }
}
