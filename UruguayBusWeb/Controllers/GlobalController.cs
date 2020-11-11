using Share.Entities;
using Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UruguayBusWeb.ApiClient;
using UruguayBusWeb.Models;
using UruguayBusWeb.Models.Proxy;

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
        public ActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO dto)
        {
            // recibe los datos del elemento
            try
            {
                if (!TryValidateModel(dto, nameof(LoginDTO)))
                {
                    return View(dto);
                }
                
                IniciarSesionDTO lg = new IniciarSesionDTO()
                {
                    correo = dto.correo,
                    contrasenia = dto.contrasenia
                };
                Usuario u = await up.IniciarSesion(lg.correo, lg.contrasenia);
                
                //Guarda los datos en la variable de sesion
                Session["datosLogeados"] = u;

                //redirige al inicio
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                // redirigir segun ele rror
                // Llama a la funcion de este controlador (no es una ruta)
                return View();
            }
        }

        // **** **** Fin de seccion de Lucas **** ****

    }
}