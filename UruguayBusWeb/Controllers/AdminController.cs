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


        // GET: Admin/RegistrarVehiculo
        public ActionResult RegistrarVehiculo()
        {
            // muestra la vista para registrar
            // carga la vista
            return View("Vehiculo/RegistrarVehiculo");
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
        public async Task<ActionResult> RegistrarHorario(CrearHorariosDTO dto)
        {
            try
            {
                ICollection<Linea> lineas = await gp.ListarLinea();
                ICollection<Conductor> Conductores = await ap.ListarConductores();
                ICollection<Vehiculo> Vehiculos = await gp.ListarVehiculos();
                ViewBag.listaLineas = lineas;
                ViewBag.listaConductores = Conductores;
                ViewBag.listaVehiculos = Vehiculos;

                if (!TryValidateModel(dto, nameof(CrearHorariosDTO)))
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
        // **** **** Fin de seccion de Lucas **** ****

    }
}
