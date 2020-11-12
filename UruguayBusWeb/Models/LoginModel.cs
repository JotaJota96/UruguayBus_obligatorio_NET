using Share.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UruguayBusWeb.Models
{
    public class LoginModel
    {
        [Required]
        [DisplayName("Correo")]
        public string correo { get; set; }

        [Required]
        [DisplayName("Contraseña")]
        public string contrasenia { get; set; }
    }
}