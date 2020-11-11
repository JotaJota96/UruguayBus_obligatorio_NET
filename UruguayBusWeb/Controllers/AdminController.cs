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

        // GET: Admin/ListarViajes
        public async Task<ActionResult> ListarViajes()
        {
            // obtiene el listado y lo pasa a la vista

            ICollection<Viaje> viajes = await ap.ListarViajes();
            ICollection<ListarViajesModel> lst = new List<ListarViajesModel>();

            foreach (var item in viajes)
            {
                ListarViajesModel lvm = new ListarViajesModel()
                {
                    fecha = item.fecha,
                    hora = item.horario.hora,
                    nombre_linea = item.horario.linea.nombre,
                    estado = item.finalizado == null ? "No iniciado" : item.finalizado == true ? "Finalizado" : "En curso",
                };
                lst.Add(lvm);
            }

            // carga la vista y pasandole el modelo
            return View("Viaje/ListarViajes", lst);
        }

        // **** **** Fin de seccion de Juan **** ****
        // **** **** Inicio de seccion de Sebastian **** ****

        // **** **** Fin de seccion de Sebastian **** ****
        // **** **** Inicio de seccion de Lucas **** ****

        // **** **** Fin de seccion de Lucas **** ****

    }
}
