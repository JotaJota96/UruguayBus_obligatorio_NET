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
            try
            {
                return dal.ListarParadas();
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un problema al intentar obtener el listado. " + e.Message);
            }
        }

        public Vehiculo ModificarVehiculo(Vehiculo v)
        {
            try
            {
                return dal.ModificarVehiculo(v);
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un problema al intentar modificar el vehiculo. " + e.Message);
            }
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
            try
            {
                return dal.RegistrarParada(p);
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un error al intentar registrar la parada. " + e.Message);
            }
        }

        public Vehiculo RegistrarVehiculo(Vehiculo v)
        {
            try
            {
                return dal.RegistrarVehiculo(v);
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un error al intentar registrar el vehiculo. " + e.Message);
            }
        }

        public ICollection<Viaje> RegistrarViajes(int idHorario, DateTime fInicio, DateTime fFin, ICollection<DiaSemana> dias)
        {
            throw new NotImplementedException();
        }
    }
}
