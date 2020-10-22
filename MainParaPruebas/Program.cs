using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using DataAccesLayer;
using MainParaPruebas.SoapService;
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

            try
            {
                
                IService1 s = new Service1Client();
                foreach (var item in s.ListarParadas())
                {
                    Console.WriteLine(item.id + " " + item.nombre);
                }
                
                /*
                foreach (var item in new BL_Admin().ListarParadas())
                {
                    Console.WriteLine(item.id + " " + item.nombre);
                }
                */
            }
            catch (Exception e)
            {
                Console.WriteLine("-------");
                Console.WriteLine("ERROR: " + e.Message);
                Console.WriteLine("-------");
            }

            Console.WriteLine("Fin de area de pruebas");
            Console.ReadLine();
        }
    }
}
