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
    //[CheckAuthentication]
    public class F_settingsController : Controller
    {
        private pastquestionEntities db = new pastquestionEntities();

        // GET: F_settings
        public ActionResult Index()
        {
            var f_settings = db.F_settings.Include(f => f.examtype).Include(f => f.examyear);
            return View(f_settings.ToList());
        }

        // GET: F_settings/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            F_settings f_settings = db.F_settings.Find(id);
            if (f_settings == null)
            {
                return HttpNotFound();
            }
            return View(f_settings);
        }

        // GET: F_settings/Create
        public ActionResult Create()
        {
            ViewBag.examtypeid = new SelectList(db.examtypes, "id", "type");
            ViewBag.examyearid = new SelectList(db.examyears, "id", "year");
            return View();
        }

        // POST: F_settings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,examyearid,examtypeid,amount,per_discount")] F_settings f_settings)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    f_settings.id = Guid.NewGuid().ToString();  //Auto generate ID 
                    db.F_settings.Add(f_settings);
                    db.SaveChanges();
                    TempData["success"] = "true";
                    TempData["message"] = "New Question created Sucessfully.";
                    return RedirectToAction("Index");
                }
                catch (Exception err)
                {
                    TempData["success"] = "false";
                    TempData["message"] = "Registration Faild, please review the fields and try again." + err.Message;
                    return View(f_settings);
                }
            }
            ViewBag.examtypeid = new SelectList(db.examtypes, "id", "type", f_settings.examtypeid);
            ViewBag.examyearid = new SelectList(db.examyears, "id", "year", f_settings.examyearid);
            return View(f_settings);
        }

        // GET: F_settings/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            F_settings f_settings = db.F_settings.Find(id);
            if (f_settings == null)
            {
                return HttpNotFound();
            }
            ViewBag.examtypeid = new SelectList(db.examtypes, "id", "type", f_settings.examtypeid);
            ViewBag.examyearid = new SelectList(db.examyears, "id", "year", f_settings.examyearid);
            return View(f_settings);
        }

        // POST: F_settings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,examyearid,examtypeid,amount,per_discount")] F_settings f_settings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(f_settings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.examtypeid = new SelectList(db.examtypes, "id", "type", f_settings.examtypeid);
            ViewBag.examyearid = new SelectList(db.examyears, "id", "year", f_settings.examyearid);
            return View(f_settings);
        }

        // GET: F_settings/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            F_settings f_settings = db.F_settings.Find(id);
            if (f_settings == null)
            {
                return HttpNotFound();
            }
            return View(f_settings);
        }

        // POST: F_settings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            F_settings f_settings = db.F_settings.Find(id);
            db.F_settings.Remove(f_settings);
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
