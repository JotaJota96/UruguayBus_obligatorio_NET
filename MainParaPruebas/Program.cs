using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using Share.Entities;
using Share.Enums;
using System;
using System.Collections.Generic;
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

            ICollection<Viaje> v = blc.ListarViajesDelDia(9);

            foreach (var item in v)
            {
                Console.WriteLine(item.fecha);
            }

            Console.WriteLine("");
        }
    }
}
