using Share.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UruguayBusWeb.Models
{
    public class CrearHorariosDTO
    {
        [Required]
        [DisplayName("Hora")]
        public TimeSpan hora { get; set; }

        [Required]
        [DisplayName("Conductores")]
        public int idConductor { get; set; }

        [Required]
        [DisplayName("Lineas")]
        public int idLinea { get; set; }

        [Required]
        [DisplayName("Vehiculo")]
        public int idVehiculo { get; set; }
    }
}