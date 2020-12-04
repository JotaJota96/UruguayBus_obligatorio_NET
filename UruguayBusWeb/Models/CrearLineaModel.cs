using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UruguayBusWeb.Models
{
    public class CrearLineaModel
    {
        [Required]
        [DisplayName("Nombre")]
        public string nombre { get; set; }

        [Required]
        public List<TramosModel> tramos { get; set; } = new List<TramosModel>();

        [Required]
        public TramosModel tramoAux { get; set; }
    }
    public class TramosModel
    {
        public int orden { get; set; }
        [Required]
        [DisplayName("Tiepo desde la parada anterior (HH:MM)")]
        public TimeSpan tiempo { get; set; }

        [Required]
        [DisplayName("Parada")]
        public int idParada { get; set; }

        [Required]
        [DisplayName("Precio desde la parada anterior")]
        public decimal precio { get; set; }
        public DateTime fecha_validez { get; set; }
    }
}