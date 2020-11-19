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

        // propiedades auxiliares

        public List<Linea> lineas { get; set; } = new List<Linea>();
        public List<Parada> paradasOrigen { get; set; } = new List<Parada>();
        public List<Parada> paradasDestino { get; set; } = new List<Parada>();

    }
}