using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Entities
{
    public class Linea
    {
        public int id { get; set; }

        [Required]
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        public ICollection<Horario> horarios { get; set; } = new List<Horario>();

        [Required]
        [DisplayName("Cantidad de paradas")]
        public ICollection<Tramo> tramos { get; set; } = new List<Tramo>();
    }
}
