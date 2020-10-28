using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using DataAccesLayer;
using MainParaPruebas.ServicioSOAP;
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
                SL_SoapClient serv = new SL_SoapClient();
                Console.WriteLine(serv.EchoTest("hola mundo"));
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
