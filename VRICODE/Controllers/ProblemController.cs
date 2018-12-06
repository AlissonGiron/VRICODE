using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using VRICODE.Core.Evaluators;
using VRICODE.Interfaces.Core;
using VRICODE.Models;
using VRICODE.Models.ViewModels;

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

        public IActionResult Visualization(int id)
        {
            return View(FCore.Get(id));
        }

        public IActionResult Evaluate(int ANidProblem, string ADesCode)
        {
            Problem LProblem = FCore.Get(ANidProblem);

            string[] LInputs = LProblem.ProblemTests.Select(p => p.DesTestInput).ToArray();
            string[] LOutputs = LProblem.ProblemTests.Select(p => p.DesTestExpectedOutput).ToArray();

            EvaluatorOutput LResult = CppCodeEvaluator.Evaluate(ADesCode, LInputs, LOutputs);

            return Json(LResult);
        }
    }
}
