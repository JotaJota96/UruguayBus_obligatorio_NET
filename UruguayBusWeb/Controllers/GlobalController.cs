using Share.Entities;
using Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // POST: Admin/RegistrarUsuario
        [HttpPost]
        public async Task<ActionResult> RegistrarUsuario(FormCollection collection)
        {
            // recibe los datos del elemento a registrar y redirige al listado
            try
            {
                Usuario u = new Usuario()
                {
                    persona = new Persona()
                    {
                        nombre = collection["nombre"],
                        apellido = collection["apellido"],
                        correo = collection["correo"],
                        contrasenia = collection["contrasenia"],
                        tipo_documento = (TipoDocumento) int.Parse(collection["tipo_documento"]),
                        documento = collection["documento"],
                    }
                };

                u = await up.RegistrarUsuario(u);

                // Llama a la funcion de este controlador (no es una ruta)
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            catch
            {
                // redirigir segun ele rror 
                // Llama a la funcion de este controlador (no es una ruta)
                return RedirectToAction("InternalServerError", "Error", new { area = "" });
            }
        }


        // **** **** Fin de seccion de Juan **** ****
        // **** **** Inicio de seccion de Sebastian **** ****

        // **** **** Fin de seccion de Sebastian **** ****
        // **** **** Inicio de seccion de Lucas **** ****

        // **** **** Fin de seccion de Lucas **** ****

    }
}