using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Interfaces
{
    public interface IDAL_Admin
    {
        Vehiculo RegistrarVehiculo(Vehiculo v);
        Vehiculo ModificarVehiculo(Vehiculo v);
        Parada RegistrarParada(Parada p);
        Parada ModificarParada(Parada p);
        ICollection<Conductor> ListarConductores();
        Conductor ModificarConductor(Conductor c);
        Horario RegistrarHorario(Horario h);
        Linea RegistrarLinea(Linea l);
        ICollection<Viaje> RegistrarViajes(ICollection<Viaje> viajes, int idHorario);
        ICollection<Viaje> ListarViajes();
        ICollection<Horario> ListarHorarios();
        Horario ModificarHorario(Horario h);
        Linea ModificarLinea(Linea l);
        Tramo ModificarTramo(Precio p);

    }
}
