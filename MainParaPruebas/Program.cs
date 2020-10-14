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
            IBL_Usuario bl = new BL_Usuario();
            IBL_Admin bla = new BL_Admin();
            
            Console.WriteLine("Fin de area de pruebas");
        }
    }
}
