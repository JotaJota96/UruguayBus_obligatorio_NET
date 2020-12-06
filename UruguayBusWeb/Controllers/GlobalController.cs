﻿using Share.Entities;
using Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using UruguayBusWeb.ApiClient;
using UruguayBusWeb.Helpers;
using UruguayBusWeb.Models;
using UruguayBusWeb.Models.Proxy;

namespace UruguayBusWeb.Controllers
{
    public class GlobalController : Controller
    {

        UsuarioProxy up = new UsuarioProxy();
        GlobalProxy gp = new GlobalProxy();
        SuperadminProxy sap = new SuperadminProxy();

        // GET: Global
        [AuthorizeRoles(usuario = true)]
        public ActionResult Index()
        {
            return View();
        }

        // **** **** Inicio de seccion de Juan **** ****

        // GET: Global/RegistrarUsuario
        [AuthorizeRoles(logueado =false)]
        public ActionResult RegistrarUsuario()
        {
            return View();
        }

        // POST: Global/RegistrarUsuario
        [HttpPost]
        [AuthorizeRoles(logueado = false)]
        public async Task<ActionResult> RegistrarUsuario(RegistrarUsuarioModel rum)
        {
            // recibe los datos del elemento a registrar y redirige al listado
            try
            {
                if ( ! TryValidateModel(rum, nameof(RegistrarUsuarioModel)))
                {
                    return View(rum);
                }
                
                Usuario u = new Usuario()
                {
                    persona = new Persona()
                    {
                        nombre = rum.nombre,
                        apellido = rum.apellido,
                        correo = rum.correo,
                        contrasenia = rum.contrasenia,
                        tipo_documento = rum.tipo_documento,
                        documento = rum.documento,
                    }
                };
                
                u = await up.RegistrarUsuario(u);

                Session["datosLogeados"] = u;
                Session["token"] = u.persona.contrasenia;

                return RedirectToAction("Index", "Usuario");
            }
            catch
            {
                // redirigir segun ele rror 
                // Llama a la funcion de este controlador (no es una ruta)
                return RedirectToAction("InternalServerError", "Error", new { area = "" });
            }
        }


        // GET: Global/Logout/
        [AuthorizeRoles(usuario = true)]
        public ActionResult Logout()
        {
            try
            {
                // limpia las varibles de sesion
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }


        // **** **** Fin de seccion de Juan **** ****
        // **** **** Inicio de seccion de Sebastian **** ****
        // POST: Global/AsignarRol/5
        [HttpPut]
        public async Task<ActionResult> AsignarRol(int id, Rol rol)
        {
            // recibe los datos del elemento a registrar y redirige al listado
            try
            {

                var res = await sap.AsignarRol(id,rol,DateTime.Now);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                // redirigir segun el error 
                // Llama a la funcion de este controlador (no es una ruta)
                return RedirectToAction("InternalServerError", "Error", new { area = "" });
            }
        }
        // **** **** Fin de seccion de Sebastian **** ****
        // **** **** Inicio de seccion de Lucas **** ****

        [AuthorizeRoles(logueado = false)]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AuthorizeRoles(logueado = false)]
        public async Task<ActionResult> Login(LoginModel dto)
        {
            // recibe los datos del elemento
            try
            {
                if (!TryValidateModel(dto, nameof(LoginModel)))
                {
                    return View(dto);
                }
                
                IniciarSesionDTO lg = new IniciarSesionDTO()
                {
                    correo = dto.correo,
                    contrasenia = dto.contrasenia
                };
                Usuario u = await up.IniciarSesion(lg.correo, lg.contrasenia);
                
                // si los datos no son correctos
                if (u == null)
                {
                    dto.loginOk = false;
                    return View(dto);
                }

                Session["datosLogeados"] = u;
                Session["token"] = u.persona.contrasenia;

                // si solo tiene un rol, es un usuario comun, y se le redirige a su pagina de inicio
                if (u.persona.GetRoles().Count == 1)
                {
                    return RedirectToAction("Index", "Usuario");
                }

                //redirige al inicio
                return RedirectToAction("Index");
            }
            catch
            {
                // redirigir segun ele rror
                // Llama a la funcion de este controlador (no es una ruta)
                Session.Remove("datosLogeados");
                return View();
            }
        }

        // **** **** Fin de seccion de Lucas **** ****

    }
}