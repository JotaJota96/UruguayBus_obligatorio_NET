using Share.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace UruguayBusWeb.Models
{
    public class ProximoVehiculoModel
    {
        public Vehiculo Vehiculo { get; set; }
        public decimal? latitud { get; set; }
        public decimal? longitud { get; set; }
        
        [DisplayName("Pasaje reservado")]
        public bool pasaje_reservado { get; set; }
    }
}