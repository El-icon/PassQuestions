using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PassQuestions.Models;

namespace PassQuestions.Controllers
{
    public class questionsController : Controller
    {
        private pastquestionEntities db = new pastquestionEntities();

        // GET: questions
        public ActionResult Index()
        {
            var questions = db.questions.Include(q => q.subject);
            return View(questions.ToList());
        }

        // GET: questions/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            question question = db.questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: questions/Create
        public ActionResult Create()
        {
            ViewBag.subjectid = new SelectList(db.subjects, "id", "name");
            return View();
        }

        // POST: questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,names,description,subjectid,examyear,examtype,insertdate,photo")] question question)
        {
            if (ModelState.IsValid)
            {
                db.questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.subjectid = new SelectList(db.subjects, "id", "name", question.subjectid);
            return View(question);
        }

        // GET: questions/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            question question = db.questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.subjectid = new SelectList(db.subjects, "id", "name", question.subjectid);
            return View(question);
        }

        // POST: questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,names,description,subjectid,examyear,examtype,insertdate,photo")] question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.subjectid = new SelectList(db.subjects, "id", "name", question.subjectid);
            return View(question);
        }

        // GET: questions/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            question question = db.questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            question question = db.questions.Find(id);
            db.questions.Remove(question);
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
