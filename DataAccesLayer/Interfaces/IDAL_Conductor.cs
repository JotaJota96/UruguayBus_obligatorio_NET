using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Interfaces
{
    public interface IDAL_Conductor
    {
        void IniciarViaje(int idViaje);
        void FinalizarViaje(int idViaje);
        ICollection<Viaje> ListarViajesDelDia(int idConductor);
        bool ValidarPasaje(int idPasaje, int idViaje, int idParada);
        ICollection<Usuario> RegistrarPasoPorParada(int idParada, int idViaje);
    }
}
