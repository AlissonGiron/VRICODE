using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VRICODE.Models;

namespace VRICODE.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public IActionResult SignIn(User AUser)
        {
            try {

                // Fazer Login
                
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
