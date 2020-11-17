using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UruguayBusWeb.ApiClient;

namespace UruguayBusWeb.Models.Validators
{
    public class CorreoDisponible : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                string correo = (string) value;
                bool CorreoExiste = Task.Run(() => new UsuarioProxy().CorreoExiste(correo)).Result;
                return !CorreoExiste;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}