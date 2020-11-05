using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceLayerREST.Models
{
    public class IniciarSesionDTO
    {
        public string correo { get; set; }
        public string contrasenia { get; set; }
    }
}