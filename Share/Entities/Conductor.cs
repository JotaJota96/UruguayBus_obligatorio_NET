using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Entities
{
    public class Conductor
    {
        public int id { get; set; }

        [DisplayName("Fecha vencimiento de la libreta")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime vencimiento_libreta { get; set; }
        public Persona persona { get; set; }
        public ICollection<Horario> horarios { get; set; } = new List<Horario>();
    }
}
