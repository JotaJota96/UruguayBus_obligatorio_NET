using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UruguayBusWeb.ApiClient;

namespace UruguayBusWeb.Controllers
{
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
        // GET: Admin/ListarVehiculos
        [HttpPost]
        public async Task<ActionResult> TomarIdPasaje(int id)
        {
            // obtiene el listado y lo pasa a la vista
            if (Session["idUltimaParada"] == null || Session["idViajeIniciado"] == null  || id == 0)
            {
                ViewBag.PasajeValido = false;
                ViewBag.mensaje = "Error al obtener los datos del viaje actual";
                return View("Validacion/TomarIdPasaje");
            }
            int idUltimaParada = (int)Session["idUltimaParada"];
            int idViaje = (int)Session["idViajeIniciado"];
            var res = await cp.ValidarPasaje(id, idViaje, idUltimaParada);
            ViewBag.PasajeValido = res;
            if (!res)
                ViewBag.mensaje = "Pasaje Inválido";
            // carga la vista y pasandole el modelo
            return View("Validacion/TomarIdPasaje");
        }
        [HttpGet]
        public ActionResult TomarIdPasaje()
        {
            return View("Validacion/TomarIdPasaje");
        }
        // **** **** Fin de seccion de Sebastian **** ****
        // **** **** Inicio de seccion de Lucas **** ****

        // **** **** Fin de seccion de Lucas **** ****

    }
}