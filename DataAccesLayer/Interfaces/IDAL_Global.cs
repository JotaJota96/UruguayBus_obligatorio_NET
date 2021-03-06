﻿using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Interfaces
{
    public interface IDAL_Global
    {
        ICollection<Parada> obtenerParadasDeLinea(int idLinea);
        ICollection<Parada> ListarParadas();
        ICollection<Vehiculo> ListarVehiculos();
        ICollection<Usuario> ListarUsuario();
        Usuario ObtenerUsuario(string correo);
        ICollection<Linea> ListarLinea();
    }
}
