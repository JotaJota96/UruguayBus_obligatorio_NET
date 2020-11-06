using BusinessLayer.Interfaces;
using DataAccesLayer.Implementations;
using DataAccesLayer.Interfaces;
using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class BL_Global : IBL_Global
    {
        private IDAL_Global dalg = new DAL_Global();

        public BL_Global()
        {
            //
        }

        public ICollection<Parada> ListarParadas()
        {
            try
            {
                return dalg.ListarParadas();
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un problema al intentar obtener el listado. " + e.Message);
            }
        }

        public ICollection<Parada> obtenerParadasDeLinea(int idLinea)
        {
            try
            {
                return dalg.obtenerParadasDeLinea(idLinea);
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un problema al intentar obtener las paradas de la linea. " + e.Message);
            }
        }

        public ICollection<Vehiculo> ListarVehiculos()
        {
            try
            {
                return dalg.ListarVehiculos();
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un problema al intentar obtener los vehiculos. " + e.Message);
            }
        }

        public Usuario ObtenerUsuario(string correo)
        {
            try
            {
                return dalg.ObtenerUsuario(correo);
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un problema al intentar obtener los vehiculos. " + e.Message);
            }
        }

        public ICollection<Linea> ListarLinea()
        {
            try
            {
                return dalg.ListarLinea();
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un problema al intentar listar las lineas. " + e.Message);
            }
        }
    }
}
