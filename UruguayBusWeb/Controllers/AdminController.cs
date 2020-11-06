using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UruguayBusWeb.ApiClient;

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

        /*
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        */


        // GET: Admin/ListarVehiculos
        public async Task<ActionResult> ListarVehiculos()
        {
            ICollection<Vehiculo> lst = await gp.ListarVehiculos();
            return View(lst);
        }


        // GET: Admin/RegistrarVehiculo
        public ActionResult RegistrarVehiculo()
        {
            return View();
        }

        // POST: Admin/RegistrarVehiculo
        [HttpPost]
        public async Task<ActionResult> RegistrarVehiculo(FormCollection collection)
        {
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

                return RedirectToAction("ListarVehiculos");
            }
            catch
            {
                return View();
            }
        }



        // GET: Admin/EditarVehiculo/5
        public async Task<ActionResult> EditarVehiculo(int id)
        {
            ICollection<Vehiculo> lst = await gp.ListarVehiculos();
            Vehiculo v = lst.Where(x => x.id == id).FirstOrDefault();
            if (v != null)
                return View(v);
            else
                return View("Home");
        }

        // POST: Admin/EditarVehiculo/5
        [HttpPost]
        public async Task<ActionResult> EditarVehiculo(int id, FormCollection collection)
        {
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

                return RedirectToAction("ListarVehiculos");
            }
            catch
            {
                return View();
            }
        }
    }
}
