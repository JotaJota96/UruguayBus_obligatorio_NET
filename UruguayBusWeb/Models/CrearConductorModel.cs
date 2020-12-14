using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UruguayBusWeb.Models
{
    public class CrearConductorModel
    {
        [Required]
        [DisplayName("Hora")]
        public DateTime vencimiento_libreta { get; set; }

        [Required]
        [DisplayName("Conductor")]
        public string documento { get; set; }
    }
}