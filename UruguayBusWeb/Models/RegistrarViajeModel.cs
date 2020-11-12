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

        // ---- Dias de la semana ----

        [DisplayName("Lunes")]
        public bool lunes { get; set; }

        [DisplayName("Martes")]
        public bool martes { get; set; }

        [DisplayName("Miércoles")]
        public bool miercoles { get; set; }

        [DisplayName("Jueves")]
        public bool jueves { get; set; }

        [DisplayName("Viernes")]
        public bool viernes { get; set; }

        [DisplayName("Sábado")]
        public bool sabado { get; set; }

        [DisplayName("Domingo")]
        public bool domingo { get; set; }

    }
}