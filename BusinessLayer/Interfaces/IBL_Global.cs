using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IBL_Global
    {
        /// <summary>
        /// Devuelve las paradas ordenadas de una linea
        /// </summary>
        /// <param name="idLinea">ID de la linea</param>
        /// <returns></returns>
        ICollection<Parada> obtenerParadasDeLinea(int idLinea);

        /// <summary>
        /// Lista todas las paradas del sistema
        /// </summary>
        /// <returns></returns>
        ICollection<Parada> ListarParadas();

    }
}
