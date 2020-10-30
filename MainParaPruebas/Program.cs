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
                IBL_Usuario blu = new BL_Usuario();
                DateTime f = new DateTime(2020, 11, 03);
                foreach (var v in blu.ListarViajesDisponibles(f, 3, 5))
                {
                    Console.WriteLine(
                        "\n----" + 
                        "\nlinea:  " + v.linea_nombre +
                        "\nviaje:  " + v.viaje_id +
                        "\nprecio: " + v.precio
                    );
                }
                Console.WriteLine("60 + 140 + 230 + 80 = 510");
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
