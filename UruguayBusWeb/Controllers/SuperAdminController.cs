using Share.Entities;
using Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using UruguayBusWeb.ApiClient;
using UruguayBusWeb.Models;
using UruguayBusWeb.Models.Proxy;

namespace UruguayBusWeb.Controllers
{
    public class SuperAdminController : Controller
    {

        UsuarioProxy up = new UsuarioProxy();
        GlobalProxy gp = new GlobalProxy();
        SuperadminProxy sap = new SuperadminProxy();

        public SuperAdminController()
        {
            //
        }

        // GET: Global
        public ActionResult Index()
        {
            return View();
        }

        // **** **** Inicio de seccion de Juan **** ****


        // **** **** Fin de seccion de Juan **** ****
        // **** **** Inicio de seccion de Sebastian **** ****
        // POST: Admin/AsignarRol/5
        [HttpPost]
        public async Task<ActionResult> AsignarRol(int id, FormCollection collection)
        {
            // recibe los datos del elemento a registrar y redirige al listado
            try
            {
                var rolId = int.Parse(collection["Rol"]);
                var res = await sap.AsignarRol(id, (Rol)rolId, DateTime.Now);
                return RedirectToAction("ListarUsuario");
            }
            catch
            {
                // redirigir segun el error 
                // Llama a la funcion de este controlador (no es una ruta)
                return RedirectToAction("InternalServerError", "Error", new { area = "" });
            }
        }
        [HttpGet]
        public async Task<ActionResult> AsignarRol(int id)
        {
            // obtiene el elemento a modificar y carga la vista de edicion

            var user = await gp.ObtenerUsuario(id);
            if (user != null)
            {
                // carga la vista y pasandole el modelo
                return View("Roles/AsignarRol", new AsignarRolModel() { Id = user.id });
            }
            else
            {
                // Llama a la funcion de este controlador (no es una ruta)
                return HttpNotFound();
            }
        }
        [HttpGet]
        public async Task<ActionResult> ListarUsuario()
        {
            // obtiene el listado y lo pasa a la vista

            ICollection<Usuario> lstUsuario = await gp.ListarUsuario();
            ICollection<Persona> lst = lstUsuario.Select(x=>x.persona).ToList();
            // carga la vista y pasandole el modelo
            return View("Roles/ListarUsuario", lst);
        }
        // **** **** Fin de seccion de Sebastian **** ****
        // **** **** Inicio de seccion de Lucas **** ****
        // **** **** Fin de seccion de Lucas **** ****

    }
}