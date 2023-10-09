using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
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
            var questions = db.questions.Include(q => q.examtype).Include(q => q.examyear).Include(q => q.subject);
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
            ViewBag.examtypeid = new SelectList(db.examtypes, "id", "type", question.examtypeid);
            ViewBag.examyearid = new SelectList(db.examyears, "id", "year", question.examyearid);
            ViewBag.subjectid = new SelectList(db.subjects, "id", "name", question.subjectid); 
            return View(question);
        }

        // GET: questions/Create
        public ActionResult Create()
        {
            ViewBag.examtypeid = new SelectList(db.examtypes, "id", "type");
            ViewBag.examyearid = new SelectList(db.examyears, "id", "year");
            ViewBag.subjectid = new SelectList(db.subjects, "id", "name");
            return View();
        }

        // POST: questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,names,description,subjectid,examyearid,examtypeid,insertdate,photo")] question question)
        {
            if (ModelState.IsValid)
            {
                try
                {
                  question.id = Guid.NewGuid().ToString();  //Auto generate ID 
                db.questions.Add(question);
                db.SaveChanges();
                TempData["success"] = "true";
                TempData["message"] = "New Question created Sucessfully.";
                return RedirectToAction("Index");
                }
                catch (Exception err)
                {
                    TempData["success"] = "false";
                    TempData["message"] = "Registration Faild, please review the fields and try again." + err.Message;
                    return View(question);
                }
            }
            ViewBag.examtypeid = new SelectList(db.examtypes, "id", "type", question.examtypeid);
            ViewBag.examyearid = new SelectList(db.examyears, "id", "year", question.examyearid);
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
            ViewBag.examtypeid = new SelectList(db.examtypes, "id", "type", question.examtypeid);
            ViewBag.examyearid = new SelectList(db.examyears, "id", "year", question.examyearid);
            ViewBag.subjectid = new SelectList(db.subjects, "id", "name", question.subjectid);
            return View(question);
        }

        // POST: questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,names,description,subjectid,examyearid,examtypeid,insertdate,photo")] question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.examtypeid = new SelectList(db.examtypes, "id", "type", question.examtypeid);
            ViewBag.examyearid = new SelectList(db.examyears, "id", "year", question.examyearid);
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



        // GET: questions
        public ActionResult PersonalFiles()
        {
            var questions = db.questions.Include(q => q.examtype).Include(q => q.examyear).Include(q => q.subject);
            return View(questions.ToList());
        }

        public ActionResult PersonelFiles(string names, string description, string subjectid, string examyearid, string examtypeid, string insertdate, string photo, string expdate, string doctype, string id, string documentid, HttpPostedFileBase file)
        {
            try
            {
                //var temp = db.Mail_Temp.Find(id);
                if (file.ContentLength > 0)
                {
                    //string _FileName = Path.GetFileName(file.FileName);
                    string fileExtention = System.IO.Path.GetExtension(file.FileName);
                    //creating filename to avoid file name conflicts.
                    string fileName = documentid;
                    //saving file in savedImage folder.
                    //string savePath = savelocation + fileName + fileExtention;

                    var folder = Server.MapPath("~/UploadedFiles/Files/" + documentid);
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles/Files/" + documentid), file.FileName);//fileName + fileExtention
                    file.SaveAs(_path);

                    //Check if file type isnot uploaded already.
                    if (db.questions.FirstOrDefault(p => p.documentid == documentid && p.id == id) == null)
                    {

                        //persisit recordsin the db
                        db.questions.Add(new question
                        {
                            id = Guid.NewGuid().ToString(),
                            //id = id,
                            names= names,
                            description= description,
                            subjectid= subjectid,
                            examyearid= examyearid,
                            examtypeid= examtypeid, 
                            photo = photo,
                            documentid = documentid,
                            url = "/UploadedFiles/Files/" + documentid + "/" + file.FileName,
                            status = "True",
                            insertdate = DateTime.Now,
                            expdate = Convert.ToDateTime(expdate),
                            doctype = doctype
                        });
                        db.SaveChanges();
                    }
                    else
                    {
                        var curPersonnel = db.questions.FirstOrDefault(p => p.documentid == documentid && p.id == id);

                        curPersonnel.url = "/UploadedFiles/Files/" + documentid + "/" + file.FileName;
                        db.SaveChanges();
                    }
                    TempData["success"] = "true";
                    TempData["message"] = "Uploaded Successfully!!";
                    return RedirectToAction("PersonelFiles/" + id, "Questions");
                }
                else  
                {
                    TempData["success"] = "false";
                    TempData["message"] = "No file selected.!!";
                    return RedirectToAction("PersonelFiles/" + id, "Questions");
                }
            }
            catch (Exception err)
            {
                TempData["success"] = "false";
                TempData["message"] = "Faild to submit, please review the entry and try again." + err.Message;
                //return View(db.studenterollments.FirstOrDefault(p => p.id == admissionid));
                return RedirectToAction("PersonelFiles/" + id, "Questions");
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
