using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UruguayBusWeb.ApiClient;

namespace UruguayBusWeb.Models.Validators
{
    /// <summary>
    /// Se supone que esto compara dos fechas.
    /// Si no se establece la propiedad 'CompareTo', se tomara por defecto DateTime.Today
    /// Si no se establece la pripiedad 'Operador', se tomara por defecto OperadorLogico.Igual
    /// </summary>
    public class DateCompare : ValidationAttribute
    {
        public OperadorLogico Operador { get; set; } = OperadorLogico.Igual;
        public DateTime CompareTo = DateTime.Today;

        public override bool IsValid(object value)
        {
            try
            {
                DateTime fecha = (DateTime) value;
                return comparar(fecha, Operador, CompareTo);
            }
            catch (Exception)
            {
                return false;
            }
        }


        private bool comparar(DateTime f1, OperadorLogico o, DateTime f2)
        {
            int resultado = f1.CompareTo(f2);
            switch (o)
            {
                case OperadorLogico.Menor:      return resultado < 0;
                case OperadorLogico.MenorIgual: return resultado <= 0;
                case OperadorLogico.Igual:      return resultado == 0;
                case OperadorLogico.MayorIgual: return resultado >= 0;
                case OperadorLogico.Mayor:      return resultado > 0;
                case OperadorLogico.Distinto:   return resultado != 0;
            }
            return false;
        }
    }

    // ***** ***** ***** ***** ***** ***** ***** ***** *****

    public enum OperadorLogico
    {
        Menor = -2,
        MenorIgual = -1,
        Igual = 0,
        MayorIgual = 1,
        Mayor = 2,
        Distinto = 10, // Numero elegido aleatoriamente por Lucas
    }
}