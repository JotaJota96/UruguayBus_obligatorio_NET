using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Entities
{
    public class Parada
    {
        public int id { get; set; }

        [DisplayName("Nombre")]
        [Required]
        public string nombre { get; set; }

        [DisplayName("Latitud")]
        [Required]
        [StringLength(90, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = -90)]
        public decimal latitud { get; set; }

        [DisplayName("Longitud")]
        [Required]
        [StringLength(180, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = -180)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{#.#}")]
        public decimal longitud { get; set; }

        public ICollection<Pasaje> pasajes_origen { get; set; } = new List<Pasaje>();
        public ICollection<Pasaje> pasajes_destino { get; set; } = new List<Pasaje>();
        public ICollection<Tramo> tramos { get; set; } = new List<Tramo>();
    }
}
