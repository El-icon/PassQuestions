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
    public class examtypesController : Controller
    {
        private pastquestionEntities db = new pastquestionEntities();

        // GET: examtypes
        public ActionResult Index()
        {
            return View(db.examtypes.ToList());
        }

        // GET: examtypes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            examtype examtype = db.examtypes.Find(id);
            if (examtype == null)
            {
                return HttpNotFound();
            }
            return View(examtype);
        }

        // GET: examtypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: examtypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,type,description")] examtype examtype)
        { 
            if (ModelState.IsValid)
            {
                try
                {
                    examtype.id = Guid.NewGuid().ToString();  //Auto generate ID 
                    db.examtypes.Add(examtype);
                    db.SaveChanges();
                    TempData["success"] = "true";
                    TempData["message"] = "New examtype created Sucessfully.";
                    return RedirectToAction("Index");
                }
                catch (Exception err)
                {
                    TempData["success"] = "false";
                    TempData["message"] = "Registration Faild, please review the fields and try again." + err.Message;
                    return View(examtype);
                }
            }
            return View(examtype);
        }

        // GET: examtypes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            examtype examtype = db.examtypes.Find(id);
            if (examtype == null)
            {
                return HttpNotFound();
            }
            return View(examtype);
        }

        // POST: examtypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,type,description")] examtype examtype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examtype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(examtype);
        }

        // GET: examtypes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            examtype examtype = db.examtypes.Find(id);
            if (examtype == null)
            {
                return HttpNotFound();
            }
            return View(examtype);
        }

        // POST: examtypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            examtype examtype = db.examtypes.Find(id);
            db.examtypes.Remove(examtype);
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
