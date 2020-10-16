using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using DataAccesLayer.Implementations;
using DataAccesLayer.Interfaces;
using Share.Entities;
using Share.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainParaPruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Area de pruebas");
            IBL_Usuario blu = new BL_Usuario();
            IBL_Conductor blc = new BL_Conductor();
            IBL_Superadmin bls = new BL_Superadmin();

            DateTime p = new DateTime(2038,11,25);
            Rol r = Rol.SUPERADMIN;

            bls.AsignarRol(1, null ,null);


            Console.WriteLine("");

        }
    }
}
