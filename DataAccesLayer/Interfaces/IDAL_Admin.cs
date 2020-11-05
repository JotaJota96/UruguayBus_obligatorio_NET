﻿using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Interfaces
{
    public interface IDAL_Admin
    {
        Vehiculo ModificarVehiculo(Vehiculo v);
        Parada RegistrarParada(Parada p);
        Vehiculo RegistrarVehiculo(Vehiculo v);
        Horario RegistrarHorario(Horario h);
        Linea RegistrarLinea(Linea l);
        ICollection<Viaje> RegistrarViajes(ICollection<Viaje> viajes, int idHorario);
        ICollection<Horario> ListarHorarios();
        Horario ModificarHorario(Horario h);
    }
}
