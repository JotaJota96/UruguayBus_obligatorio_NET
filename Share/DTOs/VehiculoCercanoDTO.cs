using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.DTOs
{
    public class VehiculoCercanoDTO
    {
        public int vehiculo_id { get; set; }
        public decimal? latitud { get; set; }
        public decimal? longitud { get; set; }
        public bool pasaje_reservado { get; set; }
    }
}
