using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UruguayBusWeb.ApiClient;

namespace UruguayBusWeb.Controllers
{
    public class GlobalController : Controller
    {

        UsuarioProxy up = new UsuarioProxy();
        GlobalProxy gp = new GlobalProxy();

        public GlobalController()
        {
            //
        }

        // **** **** Inicio de seccion de Juan **** ****

        // GET: Global/RegistrarUsuario
        public ActionResult RegistrarUsuario()
        {
            return View();
        }

        // **** **** Fin de seccion de Juan **** ****
        // **** **** Inicio de seccion de Sebastian **** ****

        // **** **** Fin de seccion de Sebastian **** ****
        // **** **** Inicio de seccion de Lucas **** ****

        // **** **** Fin de seccion de Lucas **** ****

    }
}