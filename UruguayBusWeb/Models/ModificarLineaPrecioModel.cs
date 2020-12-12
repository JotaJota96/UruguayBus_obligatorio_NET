using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UruguayBusWeb.Models
{
    public class ModificarLineaPrecioModel
    {
        [DisplayName("Parada")]
        [Required]
        public int idParada { get; set; }

        [DisplayName("Precio")]
        [Required]
        public int precio { get; set; }

        [DisplayName("Fecha de valides")]
        [Required]
        public DateTime fecha_valides { get; set; }
    }
}