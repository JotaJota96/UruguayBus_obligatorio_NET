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
    public class BL_Admin : IBL_Admin
    {
        private IDAL_Admin dal = new DAL_Admin();
        private IDAL_Global dalg = new DAL_Global();

        public BL_Admin()
        {
            //
        }

        public ICollection<Parada> ListarParadas()
        {
            throw new NotImplementedException();
        }

        public Vehiculo ModificarVehiculo(Vehiculo v)
        {
            throw new NotImplementedException();
        }

        public Horario RegistrarHorario(Horario h)
        {
            throw new NotImplementedException();
        }

        public Linea RegistrarLinea(Linea l)
        {
            throw new NotImplementedException();
        }

        public Parada RegistrarParada(Parada p)
        {
            throw new NotImplementedException();
        }

        public Vehiculo RegistrarVehiculo(Vehiculo v)
        {
            throw new NotImplementedException();
        }

        public ICollection<Viaje> RegistrarViajes(int idHorario, DateTime fInicio, DateTime fFin, ICollection<DiaSemana> dias)
        {
            throw new NotImplementedException();
        }
    }
}
