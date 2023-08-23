using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 
using PassQuestions.Setup;
using PassQuestions.Models;
using System.IO;

namespace PassQuestions.Controllers
{
    //is coming from setup folder 
    //checking if u are login in or not (if not it will take u to login page)
    [CheckAuthentication]
    public class HomeController : Controller
    {
        pastquestionEntities db = new pastquestionEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Test()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}