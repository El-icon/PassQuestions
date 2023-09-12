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
    [CheckAuthentication]
    public class examyearsController : Controller
    {
        private pastquestionEntities db = new pastquestionEntities();

        // GET: examyears
        public ActionResult Index()
        {
            return View(db.examyears.ToList());
        }

        // GET: examyears/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            examyear examyear = db.examyears.Find(id);
            if (examyear == null)
            {
                return HttpNotFound();
            }
            return View(examyear);
        }

        // GET: examyears/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: examyears/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,year,description")] examyear examyear)
        {          
            if (ModelState.IsValid)
            {
                try
                {
                    examyear.id = Guid.NewGuid().ToString();  //Auto generate ID 
                    db.examyears.Add(examyear);
                    db.SaveChanges();
                    TempData["success"] = "true";
                    TempData["message"] = "New examyear created Sucessfully.";
                    return RedirectToAction("Index");
                }
                catch (Exception err)
                {
                    TempData["success"] = "false";
                    TempData["message"] = "Registration Faild, please review the fields and try again." + err.Message;
                    return View(examyear);
                }
            }
            return View(examyear);
        }

        // GET: examyears/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            examyear examyear = db.examyears.Find(id);
            if (examyear == null)
            {
                return HttpNotFound();
            }
            return View(examyear);
        }

        // POST: examyears/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,year,description")] examyear examyear)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examyear).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(examyear);
        }

        // GET: examyears/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            examyear examyear = db.examyears.Find(id);
            if (examyear == null)
            {
                return HttpNotFound();
            }
            return View(examyear);
        }

        // POST: examyears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            examyear examyear = db.examyears.Find(id);
            db.examyears.Remove(examyear);
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
