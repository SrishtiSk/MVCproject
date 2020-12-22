using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCproject.Models;
using MVCproject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCproject.Controllers
{
    public class ExamController : Controller
    {
        IGreet ob;
        IDAL db;
        public ExamController(IGreet obj,IDAL dal)
        {
            ob = obj;
            db = dal;
        }


        public IActionResult Helo(string name, int empid)
        {
            //return Content("hai , helo,"+name+ "how r u?");

            string msg = ob.Greet(name);
            return Content(msg);


        }
        
        public IActionResult MyTime()
        {
            string result = HttpContext.Session.GetString("started");
            return Content(result);
        }
        public IActionResult Time()
        {
            // return Content(DateTime.Now.ToLongTimeString());
            //throw new Exception();
            DateTime TestStarted = DateTime.Now;
            HttpContext.Session.SetString("started", TestStarted.ToString());
            return Content(DateTime.Now.ToLongTimeString());

        }

        public IActionResult List()
        {
            //string[] exams = { "MATH", "PHY", "CHEM", "ELECTRONICS" };
            //ViewBag.Exams = exams;

            //List<Test> ExamController = new List<Test>();
            //ExamController.Add(new Test { Name = "Math", TimeGiven = "2hours", Date = DateTime.Today, Maxscore = 35 });
            //ExamController.Add(new Test { Name = "Phy", TimeGiven = "2hours", Date = DateTime.Today.AddDays(1), Maxscore = 35 });
            //ExamController.Add(new Test { Name = "Chem", TimeGiven = "3hours", Date = DateTime.Today.AddDays(2), Maxscore = 35 });
            //ExamController.Add(new Test { Name = "Electronics", TimeGiven = "2hours", Date = DateTime.Today.AddDays(3), Maxscore = 35 });
            List<Test> exams = db.GetAllExams();
            return View(exams);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Test ob)
        {
            db.AddExam(ob);
                return View("list", db.GetAllExams());
        }

       

        public IActionResult Index()
        {
            return View();  
        }





    }
}
