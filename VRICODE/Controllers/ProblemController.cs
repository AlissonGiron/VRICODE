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

        public IActionResult Create(int ANidClass)
        {
            return View(ANidClass);
        }

        [HttpPost]
        public IActionResult Create(Problem AProblem, int ANidClass)
        {
            try
            {
                FCore.Create(AProblem);
                FCore.Save();

                ProblemClass LProblemClass = new ProblemClass();
                LProblemClass.NidClass = ANidClass;
                LProblemClass.NidProblem = AProblem.NidProblem;

                FCore.CreateProblemClass(LProblemClass);    


                return RedirectToAction("Visualization", "Class", new { ANidClass = ANidClass });
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
