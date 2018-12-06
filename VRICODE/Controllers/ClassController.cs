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
            int nid = (int) HttpContext.Session.GetInt32("NidUser");

            List<Class> LClasses = FCore.FindBy(t => t.UserClasses.Any(s => s.NidUser == nid), true).ToList();

            return View(LClasses);
        }

        public IActionResult Visualization(int ANidClass)
        {
            Class LClass = FCore.Get(ANidClass);
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
                var nid = HttpContext.Session.GetInt32("NidUser");

                LUserClass.NidUser = (int) nid;
                LUserClass.NidClass = AClass.NidClass;

                FCore.CreateUserClass(LUserClass);

                return RedirectToAction("Index", "Class");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult JoinClass(int ANidClass)
        {
            try
            {
                UserClass LUserClass = new UserClass(); 
                var nid = HttpContext.Session.GetInt32("NidUser");

                LUserClass.NidUser = (int) nid;
                LUserClass.NidClass = ANidClass;

                FCore.CreateUserClass(LUserClass);

                return RedirectToAction("Visualization", "Class", new { ANidClass = ANidClass });
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
