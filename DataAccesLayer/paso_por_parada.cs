//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccesLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class paso_por_parada
    {
        public int viaje_id { get; set; }
        public int parada_id { get; set; }
        public System.DateTime fecha_hora { get; set; }
    
        public virtual parada parada { get; set; }
        public virtual viaje viaje { get; set; }
    }
}
