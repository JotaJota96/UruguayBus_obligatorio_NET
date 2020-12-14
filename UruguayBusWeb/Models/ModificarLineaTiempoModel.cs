using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UruguayBusWeb.Models
{
    public class ModificarLineaTiempoModel
    {
        [DisplayName("Parada")]
        [Required]
        public int idParada { get; set; }

        [DisplayName("Tiempo")]
        [Required]
        public TimeSpan tiempo { get; set; }
    }
}