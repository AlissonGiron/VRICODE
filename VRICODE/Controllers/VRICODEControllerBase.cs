using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VRICODE.Interfaces.Core;

namespace VRICODE.Controllers
{
    public class VRICODEControllerBase<T> : Controller where T : class
    {
        protected IVRICODECoreBase<T> FCore;

        public VRICODEControllerBase(IVRICODECoreBase<T> ACore)
        {
            FCore = ACore;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}