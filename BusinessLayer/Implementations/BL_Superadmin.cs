using BusinessLayer.Interfaces;
using DataAccesLayer.Implementations;
using DataAccesLayer.Interfaces;
using Share.Entities;
using Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class BL_Superadmin : IBL_Superadmin
    {
        private IDAL_Superadmin dal = new DAL_Superadmin();
        private IDAL_Global dalg = new DAL_Global();

        public BL_Superadmin()
        {
            //
        }

        public void AsignarRol(int idUsuario, Rol rol, DateTime? fechaVencLibreta = null)
        {
            throw new NotImplementedException();
        }

        public ICollection<Vehiculo> ListarVehiculos()
        {
            throw new NotImplementedException();
        }
    }
}
