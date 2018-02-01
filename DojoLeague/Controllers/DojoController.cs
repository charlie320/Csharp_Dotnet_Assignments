using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using DojoLeague.Models;
using DojoLeague.Factory;

namespace DojoLeague.Controllers
{
    public class DojoController : Controller
    {
        private readonly DojoFactory dojoFactory;

        public DojoController(DojoFactory connect)
        {
            //Instantiate a UserFactory object that is immutable (READONLY)
            //This establishes the initial DB connection for us.
            // NinjaFactory ninjaFactory = new NinjaFactory();
            dojoFactory = connect;
        }
        // GET: /Home/
        [HttpGet]
        [Route("dojos")]
        public IActionResult Dojos()
        {
            //We can call upon the methods of the dojoFactory directly now.
            ViewBag.dojos = dojoFactory.FindAll();
            return View("dojos");
        }
    }
}