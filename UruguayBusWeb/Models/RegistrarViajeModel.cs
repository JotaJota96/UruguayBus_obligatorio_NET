using Share.Entities;
using Share.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UruguayBusWeb.Models.Validators;

namespace UruguayBusWeb.Models
{
    public class RegistrarViajeModel
    {
        [Required]
        [DisplayName("Línea")]
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
        [RequireAtLeastOneOfGroup("GrupoDiasSemana", ErrorMessage = "Debe seleccionar al menos un dia de la semana")]
        public bool lunes { get; set; }

        [DisplayName("Martes")]
        [RequireAtLeastOneOfGroup("GrupoDiasSemana", ErrorMessage = "Debe seleccionar al menos un dia de la semana")]
        public bool martes { get; set; }

        [DisplayName("Miércoles")]
        [RequireAtLeastOneOfGroup("GrupoDiasSemana", ErrorMessage = "Debe seleccionar al menos un dia de la semana")]
        public bool miercoles { get; set; }

        [DisplayName("Jueves")]
        [RequireAtLeastOneOfGroup("GrupoDiasSemana", ErrorMessage = "Debe seleccionar al menos un dia de la semana")]
        public bool jueves { get; set; }

        [DisplayName("Viernes")]
        [RequireAtLeastOneOfGroup("GrupoDiasSemana", ErrorMessage = "Debe seleccionar al menos un dia de la semana")]
        public bool viernes { get; set; }

        [DisplayName("Sábado")]
        [RequireAtLeastOneOfGroup("GrupoDiasSemana", ErrorMessage = "Debe seleccionar al menos un dia de la semana")]
        public bool sabado { get; set; }

        [DisplayName("Domingo")]
        [RequireAtLeastOneOfGroup("GrupoDiasSemana", ErrorMessage = "Debe seleccionar al menos un dia de la semana")]
        public bool domingo { get; set; }

        // ------- funciones auxiliares

        public ICollection<DiaSemana> getDiasSeleccionados()
        {
            ICollection<DiaSemana> ret = new List<DiaSemana>();

            if (lunes)     ret.Add(DiaSemana.LUNES);
            if (martes)    ret.Add(DiaSemana.MARTES);
            if (miercoles) ret.Add(DiaSemana.MIERCOLES);
            if (jueves)    ret.Add(DiaSemana.JUEVES);
            if (viernes)   ret.Add(DiaSemana.VIERNES);
            if (sabado)    ret.Add(DiaSemana.SABADO);
            if (domingo)   ret.Add(DiaSemana.DOMINGO);

            return ret;
        }
    }
}