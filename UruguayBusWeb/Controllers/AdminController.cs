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
    public class AdminController : Controller
    {
        AdminProxy ap = new AdminProxy();
        GlobalProxy gp = new GlobalProxy();

        public AdminController()
        {
            //
        }

        
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }


        // GET: Admin/ListarVehiculos
        public async Task<ActionResult> ListarVehiculos()
        {
            // obtiene el listado y lo pasa a la vista

            ICollection<Vehiculo> lst = await gp.ListarVehiculos();
            // carga la vista y pasandole el modelo
            return View("Vehiculo/ListarVehiculos", lst);
        }

        // GET: Admin/ListarVehiculos
        public async Task<ActionResult> ListarParadas()
        {
            // obtiene el listado y lo pasa a la vista

            ICollection<Parada> lst = await gp.ListarParadas();
            // carga la vista y pasandole el modelo
            return View("Parada/ListarParadas", lst);
        }

        // GET: Admin/RegistrarVehiculo
        public ActionResult RegistrarVehiculo()
        {
            // muestra la vista para registrar
            // carga la vista
            return View("Vehiculo/RegistrarVehiculo");
        }

        // GET: Admin/RegistrarVehiculo
        public ActionResult RegistrarParada()
        {
            // muestra la vista para registrar
            // carga la vista
            return View("Parada/RegistrarParada");
        }

        // POST: Admin/RegistrarVehiculo
        [HttpPost]
        public async Task<ActionResult> RegistrarVehiculo(FormCollection collection)
        {
            // recibe los datos del elemento a registrar y redirige al listado
            try
            {
                Vehiculo v = new Vehiculo()
                {
                    cant_asientos = int.Parse(collection["cant_asientos"]),
                    marca = collection["marca"],
                    modelo = collection["modelo"],
                    matricula = collection["matricula"],
                };

                v = await ap.RegistrarVehiculo(v);

                // Llama a la funcion de este controlador (no es una ruta)
                return RedirectToAction("ListarVehiculos");
            }
            catch
            {
                // redirigir segun ele rror
                // Llama a la funcion de este controlador (no es una ruta)
                return RedirectToAction("RegistrarVehiculo");
            }
        }

        // POST: Admin/RegistrarParada
        [HttpPost]
        public async Task<ActionResult> RegistrarParada(FormCollection collection)
        {
            // recibe los datos del elemento a registrar y redirige al listado
            try
            {
                Parada P = new Parada()
                {
                    latitud = int.Parse(collection["latitud"]),
                    longitud = int.Parse(collection["longitud"]),
                    nombre = collection["nombre"],
                };

                P = await ap.RegistrarParada(P);

                // Llama a la funcion de este controlador (no es una ruta)
                return RedirectToAction("ListarParadas");
            }
            catch
            {
                // redirigir segun ele rror
                // Llama a la funcion de este controlador (no es una ruta)
                return RedirectToAction("ListarParadas");
            }
        }

        // GET: Admin/ModificarParada/5
        public async Task<ActionResult> ModificarParada(int id)
        {
            // obtiene el elemento a modificar y carga la vista de edicion

            Parada P = await gp.obtenerParada(id);

            if (P != null)
            {
                // carga la vista y pasandole el modelo
                return View("Parada/ModificarParada", P);
            }
            else
            {
                // Llama a la funcion de este controlador (no es una ruta)
                return HttpNotFound();
            }
        }

        // POST: Admin/ModificarParada/5
        [HttpPost]
        public async Task<ActionResult> ModificarParada(int id, FormCollection collection)
        {
            // recibe los datos del elemento a modificar y redirige al listado
            try
            {
                Parada P = new Parada()
                {
                    id = id,
                    latitud = int.Parse(collection["latitud"]),
                    longitud = int.Parse(collection["longitud"]),
                    nombre = collection["nombre"],
                };

                P = await ap.ModificarParada(P);

                // Llama a la funcion de este controlador (no es una ruta)
                return RedirectToAction("ListarVehiculos");
            }
            catch
            {
                // Llama a la funcion de este controlador (no es una ruta)
                return RedirectToAction("ModificarParada");
            }
        }

        // GET: Admin/ModificarVehiculo/5
        public async Task<ActionResult> ModificarVehiculo(int id)
        {
            // obtiene el elemento a modificar y carga la vista de edicion

            Vehiculo v = await gp.obtenerVehiculo(id);

            if (v != null)
            {
                // carga la vista y pasandole el modelo
                return View("Vehiculo/ModificarVehiculo", v);
            }
            else
            {
                // Llama a la funcion de este controlador (no es una ruta)
                return HttpNotFound();
            }
        }


        // POST: Admin/ModificarVehiculo/5
        [HttpPost]
        public async Task<ActionResult> ModificarVehiculo(int id, FormCollection collection)
        {
            // recibe los datos del elemento a modificar y redirige al listado
            try
            {
                Vehiculo v = new Vehiculo()
                {
                    id = id,
                    cant_asientos = int.Parse(collection["cant_asientos"]),
                    marca = collection["marca"],
                    modelo = collection["modelo"],
                    matricula = collection["matricula"],
                };

                v = await ap.ModificarVehiculo(v);

                // Llama a la funcion de este controlador (no es una ruta)
                return RedirectToAction("ListarVehiculos");
            }
            catch
            {
                // Llama a la funcion de este controlador (no es una ruta)
                return RedirectToAction("ListarVehiculos");
            }
        }

        // **** **** Inicio de seccion de Juan **** ****

        // GET: Admin/ListarViajes
        public async Task<ActionResult> ListarViajes()
        {
            // obtiene el listado y lo pasa a la vista

            ICollection<Viaje> viajes = await ap.ListarViajes();
            ICollection<ListarViajesModel> lst = viajes.Select(x => new ListarViajesModel()
                {
                    fecha = x.fecha,
                    hora = x.horario.hora,
                    nombre_linea = x.horario.linea.nombre,
                    estado = x.finalizado == null ? "No iniciado" : x.finalizado == true ? "Finalizado" : "En curso",
                })
                .Where(x => x.fecha.CompareTo(DateTime.Today) >= 0)
                .OrderBy(x => x.fecha)
                .ThenBy(x => x.hora.Hours)
                .ToList();
            // carga la vista y pasandole el modelo
            return View("Viaje/ListarViajes", lst);
        }

        // GET: Admin/RegistrarViaje
        public async Task<ActionResult> RegistrarViaje()
        {
            // muestra la vista para registrar
            // carga la vista
            ViewBag.lstLineas = await gp.ListarLinea();

            return View("viaje/RegistrarViaje");
        }

        // POST: Admin/RegistrarViaje
        [HttpPost]
        public async Task<ActionResult> RegistrarViaje(RegistrarViajeModel rvm)
        {
            try
            {
                // cargo la lista en la bolsa de la vista por si hay que redirigir
                ViewBag.lstLineas = await gp.ListarLinea();

                // Si los datos no son validos, vuelve a la misma vista
                if (!TryValidateModel(rvm, nameof(RegistrarViajeModel)))
                {
                    return View("viaje/RegistrarViaje", rvm);
                }

                await ap.RegistrarViajes(rvm.idHorario, rvm.fInicio, rvm.fFin, rvm.getDiasSeleccionados());

                return RedirectToAction("ListarViajes");
            }
            catch (Exception e)
            {
                // redirigir segun ele rror
                // Llama a la funcion de este controlador (no es una ruta)
                return RedirectToAction("RegistrarViaje");
            }
        }

        // POST: Admin/ListarHorariosDeLineaAjax
        public async Task<JsonResult> ListarHorariosDeLineaAjax(int id)
        {
            try
            {
                ICollection<Horario> horarios = await ap.ListarHorarios();

                List<SelectListItem> lstRet = horarios
                    .Where(x => x.linea.id == id)
                    .Select(x => new SelectListItem()
                    {
                        Text = "" + String.Format("{0:hh\\:mm}", x.hora),
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

        // GET: Admin/ListarHorarios
        public async Task<ActionResult> ListarHorarios()
        {
            // obtiene el listado y lo pasa a la vista

            ICollection<Horario> lst = await ap.ListarHorarios();
            // carga la vista y pasandole el modelo
            return View("Horario/ListarHorarios", lst);
        }

        // GET: Admin/RegistrarHorario
        public async Task<ActionResult> RegistrarHorario()
        {
            // muestra la vista para registrar
            // carga la vista
            try
            {
                ICollection<Linea> lineas = await gp.ListarLinea();
                ICollection<Conductor> Conductores = await ap.ListarConductores();
                ICollection<Vehiculo> Vehiculos = await gp.ListarVehiculos();

                ViewBag.listaLineas = lineas;
                ViewBag.listaConductores = Conductores;
                ViewBag.listaVehiculos = Vehiculos;

                return View("Horario/RegistrarHorario");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: Admin/RegistrarHorario
        [HttpPost]
        public async Task<ActionResult> RegistrarHorario(CrearHorariosModel dto)
        {
            try
            {
                ICollection<Linea> lineas = await gp.ListarLinea();
                ICollection<Conductor> Conductores = await ap.ListarConductores();
                ICollection<Vehiculo> Vehiculos = await gp.ListarVehiculos();
                ViewBag.listaLineas = lineas;
                ViewBag.listaConductores = Conductores;
                ViewBag.listaVehiculos = Vehiculos;

                if (!TryValidateModel(dto, nameof(CrearHorariosModel)))
                {
                    return View("Horario/RegistrarHorario", dto);
                }

                Linea l = await gp.obtenerLinea(dto.idLinea);
                Vehiculo v = await gp.obtenerVehiculo(dto.idVehiculo);
                Conductor c = await gp.obtenerConductor(dto.idConductor);

                if (l == null || v == null || c==null)
                {
                    return View("Horario/RegistrarHorario");
                }

                Horario h = new Horario()
                {
                    hora = dto.hora,

                    linea = l,
                    vehiculo = v,
                    conductor = c
                };

                await ap.RegistrarHorario(h);

                return RedirectToAction("ListarHorarios");
            }
            catch
            {
                return View("Horario/RegistrarHorario");
            }
        }

        // GET: Admin/ModificarHorario/5
        public async Task<ActionResult> ModificarHorario(int id)
        {
            // obtiene el elemento a modificar y carga la vista de edicion

            Horario h = await gp.obtenerHorario(id);

            if (h != null)
            {
                // carga la vista y pasandole el modelo
                return View("Horario/ModificarHorario", h);
            }
            else
            {
                // Llama a la funcion de este controlador (no es una ruta)
                return HttpNotFound();
            }
        }

        // POST: Admin/ModificarHorario/5
        [HttpPost]
        public async Task<ActionResult> ModificarHorario(int id, Horario dto)
        {
            // recibe los datos del elemento a modificar y redirige al listado
            try
            {
                Horario h = new Horario()
                {
                    id = id,
                    hora = dto.hora
                };

                h = await ap.ModificarHorario(h);

                // Llama a la funcion de este controlador (no es una ruta)
                return RedirectToAction("ListarHorarios");
            }
            catch
            {
                // Llama a la funcion de este controlador (no es una ruta)
                return RedirectToAction("ListarHorarios");
            }
        }



        // GET: Admin/ListarConductores
        public async Task<ActionResult> ListarConductores()
        {
            // obtiene el listado y lo pasa a la vista

            ICollection<Conductor> lst = await ap.ListarConductores();
            // carga la vista y pasandole el modelo
            return View("Conductor/ListarConductor", lst);
        }

        // GET: Admin/ModificarConductor/5
        public async Task<ActionResult> ModificarConductor(int id)
        {
            
            Conductor c = await gp.obtenerConductor(id);

            if (c != null)
            {
                // carga la vista y pasandole el modelo
                return View("Conductor/ModificarConductor", c);
            }
            else
            {
                // Llama a la funcion de este controlador (no es una ruta)
                return HttpNotFound();
            }
        }

        // POST: Admin/ModificarConductor/5
        [HttpPost]
        public async Task<ActionResult> ModificarConductor(int id, Conductor dto)
        {
            try
            {
                Conductor c = new Conductor()
                {
                    id = id,
                    vencimiento_libreta = dto.vencimiento_libreta
                };

                c = await ap.ModificarConductor(c);

                return RedirectToAction("ListarConductores");
            }
            catch
            {
                return View("Conductor/ModificarConductor");
            }
        }


        // **** **** Fin de seccion de Lucas **** ****

    }
}
