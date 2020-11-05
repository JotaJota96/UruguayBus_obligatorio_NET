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

        /// <summary>
        /// Devuelve todos los vehiculos del sistema (para saber su ubicacion)
        /// </summary>
        /// <returns></returns>
        ICollection<Vehiculo> ListarVehiculos();

        /// <summary>
        /// devuelve el usuario registrado con ese correo o null si no hay ninguno
        /// </summary>
        /// <param name="correo"></param>
        Usuario ObtenerUsuario(string correo);
    }
}
