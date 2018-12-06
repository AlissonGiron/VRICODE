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
    public class AccountController : Controller
    {
        IUserCore FCore;

        public AccountController(IUserCore ACore)
        {
            FCore = ACore;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User AUser)
        {
            try {
                FCore.Create(AUser);
                FCore.Save();

                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult SignIn(User AUser)
        {
            try 
            {
                User LUser = FCore.FindBy(t => t.NamUser == AUser.NamUser && t.DesPassword == AUser.DesPassword, true).FirstOrDefault();
                
                if(LUser == null)
                {
                    throw new Exception("Usuário ou senha incorretos");
                }

                HttpContext.Session.SetInt32("NidUser", LUser.NidUser);

                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
