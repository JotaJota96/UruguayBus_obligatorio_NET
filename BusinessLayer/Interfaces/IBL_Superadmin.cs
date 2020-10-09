using Share.DTOs;
using Share.Entities;
using Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IBL_Superadmin
    {
        /// <summary>
        /// Asigna un rol a un usuario
        /// Si el rol es CONDUCTOR se puede indicar la fecha de vencimiento de la libreta de conducir
        /// </summary>
        /// <param name="idUsuario">ID del usuario</param>
        /// <param name="rol">Rol a asignar</param>
        ///  <param name="fechaVencLibreta">Fecha de vencimiento de la libreta de conducir</param>
        void AsignarRol(int idUsuario, Rol rol, DateTime? fechaVencLibreta = null);

        /// <summary>
        /// Devuelve todos los vehiculos del sistema (para saber su ubicacion)
        /// </summary>
        /// <returns></returns>
        ICollection<Vehiculo> ListarVehiculos();

    }
}
