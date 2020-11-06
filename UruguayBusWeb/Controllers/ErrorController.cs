using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UruguayBusWeb.Controllers
{
    public class ErrorController : Controller
    {
        public ViewResult Index()
        {
            return View("Error");
        }

        public ViewResult Unauthorized()
        {
            Response.StatusCode = 200;
            return View();
        }

        public ViewResult NotFound()
        {
            Response.StatusCode = 200;
            return View();
        }

        public ViewResult InternalServerError()
        {
            Response.StatusCode = 200;
            return View();
        }

    }
}