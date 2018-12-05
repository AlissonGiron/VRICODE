using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VRICODE.Models;

namespace VRICODE.Controllers
{
    public class ProblemController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Visualization() {
            return View();
        }
    }
}
