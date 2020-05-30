using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.API.Controllers
{
    public class ValuesController : DDDControllerBase
    {
        [HttpGet]
        public ActionResult<string> GetValues()
        {
            return "Running API";
        }
    }
}
