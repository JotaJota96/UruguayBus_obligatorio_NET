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
                throw new Exception("No se pudo dar por finalizado el viaje. " + e.Message);
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
                throw new Exception("No se pudo dar por iniciado el viaje. " + e.Message);
            }
        }

        public ICollection<Viaje> ListarViajesDelDia(int idConductor)
        {
            throw new NotImplementedException();
        }

        public ICollection<Usuario> RegistrarPasoPorParada(int idParada, int idViaje)
        {
            throw new NotImplementedException();
        }

        public bool ValidarPasaje(int idPasaje, int idViaje, int idParada)
        {
            throw new NotImplementedException();
        }
    }
}
