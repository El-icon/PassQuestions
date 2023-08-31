using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PassQuestions.Models;
using PassQuestions.Setup;

namespace PassQuestions.Controllers
{
    [CheckAuthentication]
    public class questionsController : Controller
    {
        private pastquestionEntities db = new pastquestionEntities();

        // GET: questions
        public ActionResult Index()
        {
            var questions = db.questions.Include(q => q.subject);
            return View(questions.ToList());
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file, string id)
        {
            try
            {
                var question = db.questions.FirstOrDefault(p => p.id == id);
                if (file.ContentLength > 0)
                {
                    string extension = Path.GetExtension(file.FileName);
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Content/UploadedFiles"), id + extension);
                    file.SaveAs(_path);
                    question.photo = id + extension;
                }
                db.SaveChanges();
                TempData["success"] = "true";
                TempData["message"] = "File Uploaded Successfully!!";
                return RedirectToAction("Details/" + id, "questions");
            }
            catch (Exception err)
            {
                TempData["success"] = "false";
                TempData["message"] = "File upload failed!!";
                return RedirectToAction("Details/" + id, "questions");
            }
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
                try
                {
                    question.id = Guid.NewGuid().ToString();  //Auto generate ID 
                    db.questions.Add(question);
                    db.SaveChanges();
                    TempData["success"] = "true";
                    TempData["message"] = "New question created Sucessfully.";
                    return RedirectToAction("Index");
                }
                catch (Exception err)
                {
                    TempData["success"] = "false";
                    TempData["message"] = "Registration Faild, please review the fields and try again." + err.Message;
                    ViewBag.subjectid = new SelectList(db.subjects, "id", "name", question.subjectid);
                    return View(question);
                }
            }
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
