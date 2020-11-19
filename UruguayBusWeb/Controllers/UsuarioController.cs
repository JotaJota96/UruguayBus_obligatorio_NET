using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UruguayBusWeb.ApiClient;
using UruguayBusWeb.Models;

namespace UruguayBusWeb.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioProxy up = new UsuarioProxy();
        GlobalProxy gp = new GlobalProxy();

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        // **** **** Inicio de seccion de Juan **** ****

        // GET: Usuario/ComprarPasaje
        public async Task<ActionResult> ComprarPasaje()
        {
            ComprarPasajeModel cpm = new ComprarPasajeModel();
            cpm.fecha = DateTime.Today;
            cpm.lineas = (List<Share.Entities.Linea>) await gp.ListarLinea();

            return View(cpm);
        }

        // POST: Usuario/ComprarPasaje
        [HttpPost]
        public async Task<ActionResult> ComprarPasaje(ComprarPasajeModel cpm)
        {
            try
            {
                cpm.lineas = (List<Share.Entities.Linea>)await gp.ListarLinea();

                // calidacion
                if (TryValidateModel(cpm, nameof(ComprarPasaje))){
                    return View(cpm);
                }

                // hacer cosas ...

                return View(cpm);
            }
            catch (Exception)
            {
                return View(cpm);
            }
        }


        // POST: Usuario/ListarParadasDeLineaAjax
        public async Task<JsonResult> ListarParadasDeLineaAjax(int id)
        {
            try
            {
                ICollection<Parada> paradas = await gp.obtenerParadasDeLinea(id);

                List<SelectListItem> lstRet = paradas
                    .Select(x => new SelectListItem()
                    {
                        Text = "" + x.nombre,
                        Value = "" + x.id
                    }).ToList();
                return Json(lstRet, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new List<SelectListItem>(), JsonRequestBehavior.AllowGet);
            }
        }

        // **** **** Fin de seccion de Juan **** ****
        // **** **** Inicio de seccion de Sebastian **** ****

        // **** **** Fin de seccion de Sebastian **** ****
        // **** **** Inicio de seccion de Lucas **** ****

        // **** **** Fin de seccion de Lucas **** ****

    }
}