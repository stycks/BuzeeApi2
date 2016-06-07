using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuzeeApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        //static void Main()
        //{
        //    RunAsync().Wait();
        //}

        //static async Task RunAsync()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        // TODO - Send HTTP requests
        //    }
        //}
    }
}
