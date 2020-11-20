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
        // GET: Conductor/IniciarViaje
        public async Task<ActionResult> IniciarViaje()
        {
            try
            {
                Usuario u = Session["datosLogeados"] as Usuario;
                ICollection<Viaje> lstViajes = await cp.ListarViajesDelDia(u.id);

                ViewBag.listaViaje = lstViajes;

                return View("IniciarViaje");
            }
            catch (Exception)
            {
                return View("index");
            }
        }

        // POST: Conductor/IniciarViaje
        [HttpPost]
        public async Task<ActionResult> IniciarViaje(Viaje dto)
        {
            try
            {

                await cp.IniciarViaje(dto.id);
                Session["idViajeIniciado"] = dto.id;

                return View("index");
            }
            catch
            {
                Usuario u = Session["datosLogeados"] as Usuario;
                ICollection<Viaje> lstViajes = await cp.ListarViajesDelDia(u.id);

                ViewBag.listaViaje = lstViajes;

                return View("IniciarViaje");
            }
        }

        // GET: Conductor/PasoPorPaarada
        public ActionResult PasoPorParada()
        {
            try
            {
                if (Session["idViajeIniciado"] == null)
                {
                    return View("index");
                }
                PasoParadaModel ppp = new PasoParadaModel()
                {
                    idViaje = (int)Session["idViajeIniciado"],
                    idUltimaParada = -1
                };
                Session["idUltimaParada"] = -1;

                return View("PasoPorParada", ppp);
            }
            catch (Exception)
            {
                return View("index");
            }
        }

        // POST: Conductor/IniciarViaje
        [HttpPost]
        public async Task<ActionResult> PasoPorParada(PasoParadaModel ppp)
        {
            try
            {
                ppp.idUltimaParada = (int)Session["idViajeIniciado"];
                Viaje v = await gp.obtenerViaje(ppp.idViaje);
                int idLinea = v.horario.linea.id;
                ICollection<Parada> lstParada = await gp.obtenerParadasDeLinea(idLinea);

                if((int)Session["idUltimaParada"] == -1)
                {
                    await cp.RegistrarPasoPorParada(lstParada.First().id, ppp.idViaje);
                    Session["idUltimaParada"] = lstParada.First().id;
                }

                bool accion = false;
                foreach (var item in lstParada)
                {
                    if (accion)
                    {
                        await cp.RegistrarPasoPorParada(item.id, ppp.idViaje);
                        Session["idUltimaParada"] = item.id;

                        if (lstParada.Last() == item)
                        {
                            await cp.FinalizarViaje(ppp.idViaje);
                            Session["idUltimaParada"] = -1;
                            Session["idViajeIniciado"] = null;
                            return View("index");
                        }

                        accion = false; 
                        return View("PasoPorParada", ppp);
                    }

                    if (item.id == (int)Session["idUltimaParada"])
                    {
                        accion = true;
                    }
                }

                return View("PasoPorParada",ppp);
            }
            catch
            {
                return View("index");
            }
        }

    }
}