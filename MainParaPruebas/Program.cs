using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using DataAccesLayer.Implementations;
using DataAccesLayer.Interfaces;
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
            IDAL_Global blg = new DAL_Global();

            ICollection<Usuario> usu = blc.RegistrarPasoPorParada(1,6);

            foreach (var item in usu)
            {
                Console.WriteLine(item.persona.nombre);
            }


            Console.WriteLine("");

        }
    }
}
