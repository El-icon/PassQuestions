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
    public class paymentsController : Controller
    {
        private pastquestionEntities db = new pastquestionEntities();

        // GET: payments
        public ActionResult Index()
        {
            var payments = db.payments.Include(p => p.F_settings).Include(p => p.useraccount);
            return View(payments.ToList());
        }

        // GET: payments/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            payment payment = db.payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: payments/Create
        public ActionResult Create()
        {
            ViewBag.feeid = new SelectList(db.F_settings, "id", "examyearid");
            ViewBag.userid = new SelectList(db.useraccounts, "id", "name");
            return View();
        }

        // POST: payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,feeid,name,trxid,email,userid,phone,amount,tenxdate,status,notes,gatewayref,ptype,insertuser,insertdate")] payment payment)
        {
            if (ModelState.IsValid)
            {
                db.payments.Add(payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.feeid = new SelectList(db.F_settings, "id", "examyearid", payment.feeid);
            ViewBag.userid = new SelectList(db.useraccounts, "id", "name", payment.userid);
            return View(payment);
        }

        // GET: payments/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            payment payment = db.payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.feeid = new SelectList(db.F_settings, "id", "examyearid", payment.feeid);
            ViewBag.userid = new SelectList(db.useraccounts, "id", "name", payment.userid);
            return View(payment);
        }

        // POST: payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,feeid,name,trxid,email,userid,phone,amount,tenxdate,status,notes,gatewayref,ptype,insertuser")] payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.feeid = new SelectList(db.F_settings, "id", "examyearid", payment.feeid);
            ViewBag.userid = new SelectList(db.useraccounts, "id", "name", payment.userid);
            return View(payment);
        }

        // GET: payments/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            payment payment = db.payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            payment payment = db.payments.Find(id);
            db.payments.Remove(payment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: payments/Create
        public ActionResult payments()
        {            
            return View();
        }


       
        [HttpPost]
        public ActionResult payments(string feeid, string name,string email, string userid,string phone,decimal amount)
        {
            string id = Guid.NewGuid().ToString();
            db.initializepayments.Add(new initializepayment
            {
                id = id,
                feeid = feeid,
                name = name,
                email = email,
                userid = Session["userid"].ToString(), //"325DC503", //userid,
                phone = phone,
                amount = amount,
                status = "PENDING",
                insertdate = DateTime.Now,
                tenxdate = DateTime.Now
            });
            db.SaveChanges();
            return RedirectToAction("paynow", new {id = id});
        }

        public ActionResult paynow(string id)
        {
            return View(db.initializepayments.Find(id));
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult paynow(string paymentid, string id, decimal amountpaid, string trnxid, string paid_by, string pay_email, string pay_phone, string pay_status, string ref_no, string gateway_ref, string currency) //paid, pay_date
        {
            //var payment = db.payments.Find(paymentid);
            //payment.status = "PAID";
            //payment.ptype = "ONLINE";
            //payment.trxid = paymentid;
            //payment.gatewayref = gateway_ref;
            //payment.notes = "Ref No: " + ref_no + " Gateway_ref: " + gateway_ref + " currency: " + currency;

            //int no = db.bookings.Where(p => p.batchid == id).Count();
            //decimal costper = amountpaid / no;
            db.payments.Add(new Models.payment
            {
                id = paymentid,
                name = paid_by,
                trxid = paymentid,
                email = pay_email,
                phone = pay_phone,
                status = pay_status,
                userid = Session["userid"].ToString(),
                amount = amountpaid,
                insertdate = DateTime.Now,
                tenxdate = DateTime.Now,
                notes = "Ref No: " + ref_no + " Gateway_ref: " + gateway_ref + " currency: " + currency,
                gatewayref = gateway_ref,
                ptype = "ONLINE"
            });
            db.SaveChanges();
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
        public ActionResult receipt(string id)
        {
            return View(db.payments.Find(id));
        }



        public ActionResult Paymentreport()
        {
            DateTime sdate = DateTime.Now.Date;
            DateTime edate = DateTime.Now.Date.AddDays(1);
            Session["startdate"] = sdate;
            Session["enddate"] = edate;
            ViewBag.sdate = sdate;
            ViewBag.edate = edate;
            var sal = db.payments.Where(p => p.insertdate >= sdate && p.insertdate < edate);
            return View(sal.ToList());
        }
        [HttpPost]
        public ActionResult Paymentreport(string startdate, string enddate, string userid)
        {
            DateTime sdate = Convert.ToDateTime(startdate).Date;
            DateTime edate = Convert.ToDateTime(enddate).Date.AddDays(1);

            Session["startdate"] = sdate;
            Session["enddate"] = edate;
            ViewBag.sdate = sdate;
            ViewBag.edate = edate;
            if (userid == "success")
            {
                var sal = db.payments.Where(p => p.insertdate >= sdate && p.insertdate < edate && p.status == "success");
                return View(sal.ToList());
            }
            else
            if (userid == "PENDING")
            {
                var sal = db.payments.Where(p => p.insertdate >= sdate && p.insertdate < edate && p.status == "PENDING");
                return View(sal.ToList());
            }
            else
            {
                var sal = db.payments.Where(p => p.insertdate >= sdate && p.insertdate < edate);
                return View(sal.ToList());
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
