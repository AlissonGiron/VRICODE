using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VRICODE.Models;

namespace VRICODE.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Group()
        {
            Class LClass = new Class();
            LClass.NamClass = "EPN001";
            LClass.ProblemClasses = new List<ProblemClass>() {
                new ProblemClass() {
                    Problem = new Problem() {
                        DesTitle = "OI"
                    }
                },
                new ProblemClass() {
                    Problem = new Problem() {
                        DesTitle = "Tudo"
                    }
                },
                new ProblemClass() {
                    Problem = new Problem() {
                        DesTitle = "Joia"
                    }
                }
            };

            return View(LClass);
        }

        public IActionResult Create()
        {
            return View();
        }

    }
}
