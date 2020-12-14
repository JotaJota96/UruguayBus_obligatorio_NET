using Share.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UruguayBusWeb.Models
{
    public class CrearHorariosModel
    {
        [Required]
        [DisplayName("Hora")]
        public TimeSpan hora { get; set; }

        [Required]
        [DisplayName("Conductor")]
        public int idConductor { get; set; }

        [Required]
        [DisplayName("Línea")]
        public int idLinea { get; set; }

        [Required]
        [DisplayName("Vehículo")]
        public int idVehiculo { get; set; }
    }
}