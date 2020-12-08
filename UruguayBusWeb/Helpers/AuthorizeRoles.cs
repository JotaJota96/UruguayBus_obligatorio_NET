using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UruguayBusWeb.Helpers
{
    public class AuthorizeRoles : AuthorizeAttribute
    {
        public bool logueado { get; set; } = true;

        public bool admin { get; set; } = false;
        public bool superadmin { get; set; } = false;
        public bool usuario { get; set; } = false;
        public bool conductor { get; set; } = false;

        /// <summary>
        /// Devuelve true si se le aturoiza el acceso
        /// Se debe establecer en true las variables segun el rol que se quiere dejar pasar.
        /// Las variables son: admin, superadmin, usuario, conductor
        /// </summary>
        /// <param name="contextoHTTP"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase contextoHTTP)
        {
            bool permitirAcceso = false;
            Usuario u = (Usuario) contextoHTTP.Session["datosLogeados"];

            if (logueado)
            {
                if (u == null) return false;

                if (admin && u.persona.admin != null) permitirAcceso = true;
                if (superadmin && u.persona.superadmin != null) permitirAcceso = true;
                if (conductor && u.persona.conductor != null) permitirAcceso = true;
                if (usuario && u != null) permitirAcceso = true;

                return permitirAcceso;
            }
            else
            {
                return u == null;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }

    }
}