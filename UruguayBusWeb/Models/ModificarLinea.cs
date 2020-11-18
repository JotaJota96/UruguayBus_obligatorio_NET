using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UruguayBusWeb.Models
{
    public class ModificarLinea
    {
        [DisplayName("Nombre")]
        public string nombre { get; set; }

        [DisplayName("Parada")]
        public int? idParada { get; set; } = null;

        [Required]
        [DisplayName("Precio")]
        public int? precio { get; set; } = null;

        [DisplayName("Fecha de valides")]
        public DateTime? fecha_valides { get; set; } = null;

        [DisplayName("Tiempo")]
        public TimeSpan? tiempo { get; set; } = null;
    }
}