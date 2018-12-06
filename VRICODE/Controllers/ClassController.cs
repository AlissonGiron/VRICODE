using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VRICODE.Interfaces.Core;
using VRICODE.Models;

namespace VRICODE.Controllers
{
    public class ClassController : Controller
    {

        IClassCore FCore;

        public ClassController(IClassCore ACore)
        {
            FCore = ACore;
        }

        public IActionResult Index() 
        {
            return View();
        }

        public IActionResult Visualization()
        {
            

            Class LClass = new Class();
            LClass.NamClass = "ewewer234rffdsfs";

            LClass.ProblemClasses = new List<ProblemClass>();

            return View(LClass);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Class AClass)
        {
            try {

                FCore.Create(AClass);
                FCore.Save();

                UserClass LUserClass = new UserClass(); 
                LUserClass.NidUser = (int) HttpContext.Session.GetInt32("NidUser");
                LUserClass.NidClass = AClass.NidClass;

                FCore.CreateUserClass(LUserClass);

                return RedirectToAction("Index", "Class");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
