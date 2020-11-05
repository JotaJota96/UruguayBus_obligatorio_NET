using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.DTOs
{
    /// <summary>
    /// Este DTO sirve para dar informacion util para el caso de uso de reservar pasajes
    /// </summary>
    public class ViajeDisponibleDTO
    {
        public int viaje_id { get; set; }
        public string linea_nombre { get; set; }
        public int parada_id_origen { get; set; }
        public int parada_id_destino { get; set; }
        public TimeSpan hora { get; set; }
        public decimal precio { get; set; }
        public ICollection<int> asientos_disponibles { get; set; } = new List<int>();
    }
}
