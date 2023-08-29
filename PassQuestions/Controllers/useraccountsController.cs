using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PassQuestions.Models;
using PassQuestions.Setup;

namespace PassQuestions.Controllers
{
    //is coming from setup folder
    //checking if u are login in or not (if not it will take u to login page)
    //[CheckAuthentication]
    public class useraccountsController : Controller
    {
        private pastquestionEntities db = new pastquestionEntities();

        // GET: useraccounts
        public ActionResult Index()
        {
            return View(db.useraccounts.ToList());
        }


        //Login Page 
        public ActionResult Login()
        {   //
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            //string email = form["email"];
            //string password = form["password"];
            List<string> Meassage = new List<string>();
            string clearpassword;
            Meassage.Add("Login failed. Please review your credentials and login again!! ");

            var User = db.useraccounts.FirstOrDefault(u => u.email == email);
            if (User != null)
            {
                clearpassword = PassQuestions.Setup.CryptoEngine.Decrypt(User.password);
                if (password == clearpassword)
                {
                    Session["userid"] = User.id.ToString();
                    Session["email"] = User.email.ToString();
                    Session["usertype"] = User.usertype;
                    // Session["branchid"] = User.branchid;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = Meassage[0];
                    return View();
                }
            }
            else
            {
                ViewBag.error = Meassage[0];
                return View();
            }
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string name, string address, 
            string email, string phone, string insertdate, string password)
        {
            db.useraccounts.Add(new useraccount
            {
                id = Setup.GenerateID.GetID(),
                name = name,
                address = address,
                email = email,
                phone = phone,        
                insertdate = DateTime.Now,
                password = Setup.CryptoEngine.Encrypt(password),
                //status = "ACTIVE",
                usertype = "USER"
            });
            db.SaveChanges();
            TempData["success"] = "true";
            TempData["message"] = "You have successfully registered. Please Login to continue."; // err.Message
            return RedirectToAction("Login", "useraccounts");
        }




        //Log out User from the system
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "UserAccounts");
        }


        // GET: useraccounts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            useraccount useraccount = db.useraccounts.Find(id);
            if (useraccount == null)
            {
                return HttpNotFound();
            }
            return View(useraccount);
        }

        // GET: useraccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: useraccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,phone,address,email,password,insertdate,usertype")] useraccount useraccount)
        {
            if (ModelState.IsValid)
            {
                useraccount.id = Setup.GenerateID.GetID();
                useraccount.password = Setup.CryptoEngine.Encrypt(useraccount.password);
                //useraccount.isactive = "true";
                useraccount.insertdate = DateTime.Now;
                //useraccount.updatedate = DateTime.Now;
                db.useraccounts.Add(useraccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(useraccount);
        }

        // GET: useraccounts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            useraccount useraccount = db.useraccounts.Find(id);
            if (useraccount == null)
            {
                return HttpNotFound();
            }
            return View(useraccount);
        }

        // POST: useraccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,phone,address,email,password,insertdate,usertype")] useraccount useraccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(useraccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(useraccount);
        }

        // POST: useraccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            useraccount useraccount = db.useraccounts.Find(id);
            db.useraccounts.Remove(useraccount);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ResetPassword(string id)
        {
            return View(db.useraccounts.Find(id));
        }
        [HttpPost]
        public ActionResult ResetPassword(string id, string password)
        {
            try
            {
                var user = db.useraccounts.FirstOrDefault(p => p.id == id);
                user.password = Setup.CryptoEngine.Encrypt(password);
                db.SaveChanges();
                TempData["success"] = "true";
                TempData["message"] = "Password reset Success!!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["success"] = "false";
                TempData["message"] = "Failed to reset Password!!";
                return RedirectToAction("ResetPassword/" + id, "Students");
            }
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
