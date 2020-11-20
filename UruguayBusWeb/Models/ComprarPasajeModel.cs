using Share.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UruguayBusWeb.Models.Validators;

namespace UruguayBusWeb.Models
{
    public class ComprarPasajeModel
    {
        [Required]
        [DateCompare(Operador =OperadorLogico.MayorIgual, ErrorMessage = "La fecha debe ser igual o posterior a hoy")]
        [DisplayName("Fecha")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fecha { get; set; }

        [Required]
        [DisplayName("Linea")]
        public int idLinea { get; set; }

        [Required]
        [DisplayName("Parada de origen")]
        public int idParadaOrigen { get; set; }

        [Required]
        [DisplayName("Parada de destino")]
        public int idParadaDestino { get; set; }

        [Required]
        [DisplayName("Asiento")]
        public int asiento { get; set; } = 0;

        // propiedades auxiliares
        public decimal precioElegirAsiento { get; set; }
        public List<Linea> lineas { get; set; } = new List<Linea>();

    }
}