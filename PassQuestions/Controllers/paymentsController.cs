using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PassQuestions.Models;
using PassQuestions.Setup;
using System.Web.Helpers;
using Paystack.Net.SDK.Transactions;
using System.Configuration;
using System.Threading.Tasks;

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

         public ActionResult book_question(string name, string email, string phone, string address, string feeid, string trxid, string date, string userid, decimal amount,
            string tenxdate, string status, string insertdate, string booking_date, string paymentid, string refno, string ptype, string notes, string insertuser, string attendance_status, string examtype, string examyear)
        {
            DateTime visitDate = Convert.ToDateTime(date);
            string days = Convert.ToString(visitDate.DayOfWeek);
            //var bookingFee = db.B_settings.Where(p => p.days == days && p.cat == "online").ToList();

            string id = "PASTQUESTION" + Setup.GenerateID.GetID();
            // Guid.NewGuid().ToString();
            // 
            //var AdultFee = bookingFee.Where(p => p.item == "adult").FirstOrDefault();
            //var ChildrenFee = bookingFee.Where(p => p.item == "children").FirstOrDefault();

            //decimal ChildrenAmount = Convert.ToDecimal(ChildrenFee.amount);
            //decimal AdultAmount = Convert.ToDecimal(AdultFee.amount);

            //decimal percAdultAmount = Convert.ToDecimal((AdultFee.perc_discount / 100) * (AdultAmount * Convert.ToDecimal(adult)));
            //decimal percChildrenAmount = Convert.ToDecimal((ChildrenFee.perc_discount / 100) * (ChildrenAmount * Convert.ToDecimal(children)));


            //decimal totalAmount = Convert.ToDecimal((ChildrenAmount * Convert.ToDecimal(children)) + (AdultAmount * Convert.ToDecimal(adult))) - (percAdultAmount + percChildrenAmount);

            db.B_booking.Add(new B_booking()
            {
                id = id,
                name = name,
                email = email,
                phone = phone,
                address = address,
                feeid = feeid,
                trxid = trxid,
                userid = Session["userid"].ToString(),
                amount = amount,
                tenxdate = DateTime.Now,
                status = "BOOKED",
                insertdate = DateTime.Now,
                paymentid = paymentid,
                refno = refno,
                examtype = examtype,
                examyear = examyear,
                booking_date = Convert.ToDateTime(date),
                ptype = "PENDING",
                attendance_status = "PENDING",
                insertuser = email, //Session["email"].ToString(),
                notes = "Paid online on: " + DateTime.Now + ""
            });
            db.SaveChanges();
            return RedirectToActionPermanent("paynow/" + id, "Payments");
        }

        public ActionResult book_questionpayment(string id)
        {
            return View(db.B_booking.FirstOrDefault(p => p.id == id));
        }
        //[CheckAuthentication]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult payment(string bookingid, string id, decimal amountpaid, string trnxid, string paid_by, string pay_email, string pay_phone, string pay_status, string ref_no, string gateway_ref, string currency) //paid, pay_date
        {
            var booking = db.B_booking.Find(bookingid);
            booking.status = "PAID";
            booking.ptype = "ONLINE";
            //int no = db.bookings.Where(p => p.batchid == id).Count();
            //decimal costper = amountpaid / no;
            db.payments.Add(new Models.payment
            {
                id = id,
                name = paid_by,
                trxid = bookingid,
                email = pay_email,
                phone = pay_phone,
                status = pay_status,
                userid = booking.email,
                amount = amountpaid,
                tenxdate = DateTime.Now,
                notes = "Ref No: " + ref_no + " Gateway_ref: " + gateway_ref + " currency: " + currency,
                gatewayref = gateway_ref,
                ptype = "ONLINE"
            });
            db.SaveChanges();
            return Json("Success", JsonRequestBehavior.AllowGet);
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


        //public async Task<JsonResult> VerifyPayment(string id)
        //{
        //    string secretKey = ConfigurationManager.AppSettings["Paystack_SEC_Live"];
        //    var paystackTransactionAPI = new PaystackTransaction(secretKey);
        //    var tranxRef = id; // HttpContext.Request.QueryString["reference"];
        //    if (tranxRef != null)
        //    {
        //        var response = await paystackTransactionAPI.VerifyTransaction(tranxRef);
        //        if (response.status)
        //        {
        //            return Json(response, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json("error: " + response.status + " msg: " + response.message, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    else
        //    {
        //        return Json("error: ref is null", JsonRequestBehavior.AllowGet);
        //    }
        //}

        //[HttpPost]
        //public async Task<JsonResult> ValidatePayments(string id)
        //{
        //    string secretKey = ConfigurationManager.AppSettings["Paystack_SEC_Live"];
        //    var paystackTransactionAPI = new PaystackTransaction(secretKey);
        //    var tranxRef = id; // HttpContext.Request.QueryString["reference"];
        //    if (tranxRef != null)
        //    {

        //        var response = await paystackTransactionAPI.VerifyTransaction(tranxRef);
        //        if (response.data.status == "success")
        //        {
        //            var booking = db.B_booking.Find(id);
        //            //get payment
        //            var payments = db.payments.FirstOrDefault(p => p.trxid == booking.id);

        //            if (payments == null)
        //            {
        //                //if the payment doesnot exists create a new one 
        //                db.payments.Add(new Models.payment
        //                {
        //                    id = id,
        //                    name = booking.name,
        //                    trxid = booking.id,
        //                    email = booking.email,
        //                    phone = booking.phone,
        //                    status = response.data.status,
        //                    userid = booking.email,
        //                    amount = response.data.amount,
        //                    tenxdate = DateTime.Now,
        //                    notes = "Ref No: " + response.data.reference + " Gateway_ref: " + response.data.reference + " currency: " + response.data.currency,
        //                    gatewayref = response.data.reference,
        //                    ptype = "ONLINE"
        //                });
        //            }
        //            else
        //            {
        //                payments.name = booking.name;
        //                payments.trxid = booking.id;
        //                payments.email = booking.email;
        //                payments.phone = booking.phone;
        //                payments.status = response.data.status;
        //                payments.userid = booking.email;
        //                payments.amount = response.data.amount;
        //                payments.tenxdate = DateTime.Now;
        //                payments.notes = "Ref No: " + response.data.reference + " Gateway_ref: " + response.data.reference + " currency: " + response.data.currency;
        //                payments.gatewayref = response.data.reference;
        //                payments.ptype = "ONLINE";
        //            }

        //            booking.status = "PAID";
        //            booking.ptype = "ONLINE";
        //            db.SaveChanges();
        //            return Json(response, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json("error: " + response.data.status + " msg: " + response.message, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    else
        //    {
        //        return Json("error: ref is null", JsonRequestBehavior.AllowGet);
        //    }
        //}

        //[HttpPost]
        //public async Task<ActionResult> VerifyPaymentMade(string id)
        //{
        //    string secretKey = ConfigurationManager.AppSettings["Paystack_SEC_Live"];
        //    var paystackTransactionAPI = new PaystackTransaction(secretKey);
        //    var tranxRef = id; // HttpContext.Request.QueryString["reference"];
        //    var booking = db.B_booking.Find(id);
        //    if (tranxRef != null)
        //    {
        //        var response = await paystackTransactionAPI.VerifyTransaction(tranxRef);
        //        if (response.data.status == "success")
        //        {
        //            booking.status = "PAID";
        //            booking.ptype = "ONLINE";
        //            db.SaveChanges();

        //            return View("Ticket", "Booking", new { id = id });
        //        }
        //        else
        //        {
        //            ViewBag.msg = response.message;
        //            return View("BookingReport", "Booking");
        //        }
        //    }
        //    else
        //    {
        //        ViewBag.msg = "id is null";
        //        return View("BookingReport", "Booking");
        //    }
        //}



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
