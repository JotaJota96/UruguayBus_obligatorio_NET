using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UruguayBusWeb.ApiClient;
using UruguayBusWeb.Helpers;

namespace UruguayBusWeb.Controllers
{
    [AuthorizeRoles(conductor = true)]
    public class ConductorController : Controller
    {
        ConductorProxy cp = new ConductorProxy();
        GlobalProxy gp = new GlobalProxy();

        // GET: Conductor
        public ActionResult Index()
        {
            return View();
        }

        // **** **** Inicio de seccion de Juan **** ****

        // **** **** Fin de seccion de Juan **** ****
        // **** **** Inicio de seccion de Sebastian **** ****

        // **** **** Fin de seccion de Sebastian **** ****
        // **** **** Inicio de seccion de Lucas **** ****

        // **** **** Fin de seccion de Lucas **** ****

    }
}