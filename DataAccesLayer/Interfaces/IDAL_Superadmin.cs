﻿using Share.Entities;
using Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Interfaces
{
    public interface IDAL_Superadmin
    {
        void AsignarRol(int idUsuario, Rol rol, DateTime? fechaVencLibreta);
    }
}
