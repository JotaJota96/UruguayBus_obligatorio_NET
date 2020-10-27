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
    public class BL_Conductor : IBL_Conductor
    {
        private IDAL_Conductor dal = new DAL_Conductor();
        private IDAL_Global dalg = new DAL_Global();

        public BL_Conductor()
        {
            //
        }


        public void FinalizarViaje(int idViaje)
        {
            try
            {
                dal.FinalizarViaje(idViaje);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo finalizar el viaje: " + e.Message);
            }
        }

        public void IniciarViaje(int idViaje)
        {
            try
            {
                dal.IniciarViaje(idViaje);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo iniciar el viaje: " + e.Message);
            }
        }

        public ICollection<Viaje> ListarViajesDelDia(int idConductor)
        {
            try
            {
                return dal.ListarViajesDelDia(idConductor);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo obtener la lista de viaje: " + e.Message);
            }
        }

        public ICollection<Usuario> RegistrarPasoPorParada(int idParada, int idViaje)
        {
            try
            {
                return dal.RegistrarPasoPorParada(idParada, idViaje);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo obtener la lista de pasajeros: " + e.Message);
            }
        }

        public bool ValidarPasaje(int idPasaje, int idViaje, int idParada)
        {
            try
            {
                return dal.ValidarPasaje(idPasaje, idViaje, idParada);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo validar el pasaje: " + e.Message);
            }
        }
    }
}
