using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VRICODE.Core.CodeRunners;
using VRICODE.Interfaces.Core;
using VRICODE.Models;

namespace VRICODE.Controllers
{
    public class ProblemController : Controller
    {

        IProblemCore FCore;

        public ProblemController(IProblemCore ACore)
        {
            FCore = ACore;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Problem AProblem)
        {
            try
            {
                FCore.Create(AProblem);
                FCore.Save();

                return RedirectToAction("Index", "Class");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult Visualization()
        {
            Problem LProblem = new Problem();
            LProblem.DesTitle = "Exercicio 0341: dojoijiowejqoe";
            LProblem.DesProblem = "ew1ewedkiojiojioejiw1e2";

            LProblem.ProblemTests = new List<ProblemTest>() {
                new ProblemTest() { FlgVisibleToUser = false, DesTestInput = "15", DesTestExpectedOutput = "25" },
                new ProblemTest() { FlgVisibleToUser = true, DesTestInput = "14", DesTestExpectedOutput = "312" },
                new ProblemTest() { FlgVisibleToUser = true, DesTestInput = "10", DesTestExpectedOutput = "523" },
                new ProblemTest() { FlgVisibleToUser = false, DesTestInput = "153", DesTestExpectedOutput = "43523" }
            };

            return View(LProblem);
        }
    }
}
