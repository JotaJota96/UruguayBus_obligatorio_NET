using Share.Entities;
using Share.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UruguayBusWeb.Models
{
    public class RegistrarViajeModel
    {
        [Required]
        [DisplayName("Linea")]
        public int idLinea { get; set; }

        [Required]
        [DisplayName("Horario")]
        public int idHorario { get; set; }

        [DisplayName("Fecha de inicio")]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fInicio { get; set; }

        [DisplayName("Fecha de fin")]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fFin { get; set; }

        [Required]
        public ICollection<DiaSemana> dias { get; set; } = new List<DiaSemana>();

    }
}