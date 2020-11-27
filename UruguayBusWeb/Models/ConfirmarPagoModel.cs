using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace UruguayBusWeb.Models
{
    public class ConfirmarPagoModel
    {

        public ConfirmarPagoResult accion { get; set; } = ConfirmarPagoResult.ConfirmarDatos;

        // Informacion para mostrarle al usuario

        [DisplayName("Linea")]
        public string nombreLinea { get; set; }


        [DisplayName("Parada de origen")]
        public string nombreParadaOrigen { get; set; }


        [DisplayName("Parada de destino")]
        public string nombreParadaDestino { get; set; }


        // Información necesaria para el funcionamiento

        [DisplayName("ID viaje")]
        public int idViaje { get; set; }


        [DisplayName("Fecha")]
        public DateTime fecha { get; set; }


        [DisplayName("ID linea")]
        public int idLinea { get; set; }


        [DisplayName("ID parada de origen")]
        public int idParadaOrigen { get; set; }


        [DisplayName("ID parada de destino")]
        public int idParadaDestino { get; set; }


        [DisplayName("Asiento")]
        public int asiento { get; set; } = 0;


        [DisplayName("Precio")]
        public decimal precio { get; set; }

        // informacion aportada por MercadoPago


        /// <summary>
        /// Identificador único de la tarjeta tokenizada
        /// </summary>
        [DisplayName("Token")]
        public string token { get; set; }

        /// <summary>
        /// Medio de pago elegido por el comprador
        /// </summary>
        [DisplayName("ID del metodo de pago")]
        public string payment_method_id { get; set; }

        /// <summary>
        /// Cantidad de cuotas elegidas por el comprador
        /// </summary>
        [DisplayName("Cantidad de cuotas")]
        public int? installments { get; set; }

        /// <summary>
        /// ID del emisor de la tarjeta del comprador
        /// </summary>
        [DisplayName("ID del emisor de la tarjeta")]
        public string issuer_id { get; set; }

    }

    // ***** ***** ***** ***** ***** ***** ***** *****

    public enum ConfirmarPagoResult
    {
        Error = 0,
        Ok = 1,
        ConfirmarDatos = 2,
    }
}