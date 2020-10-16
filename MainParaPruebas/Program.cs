using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using DataAccesLayer;
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

            Precio p;
            Tramo t;
            ICollection<Tramo> tramos = new List<Tramo>();


            p = new Precio() { valor = 0, fecha_validez = new DateTime(2020, 01, 01), };
            t = new Tramo()
            {
                parada = new Parada() { id = 1 },
                numero = 1,
                tiempo = new TimeSpan(00, 00, 00),
            };
            t.precio.Add(p);
            tramos.Add(t);


            p = new Precio() { valor = 50, fecha_validez = new DateTime(2020, 01, 01), };
            t = new Tramo()
            {
                parada = new Parada() { id = 2 },
                numero = 2,
                tiempo = new TimeSpan(00, 30, 00),
            };
            t.precio.Add(p);
            tramos.Add(t);


            p = new Precio() { valor = 100, fecha_validez = new DateTime(2020, 01, 01), };
            t = new Tramo()
            {
                parada = new Parada() { id = 3 },
                numero = 3,
                tiempo = new TimeSpan(01, 00, 00),
            };
            t.precio.Add(p);
            tramos.Add(t);


            Linea l = new Linea() {
                nombre = "testing",
                tramos = tramos,
            };

            try
            {
                l = bla.RegistrarLinea(l);

                Console.WriteLine("Linea id = " + l.id);
                Console.WriteLine("Linea nombre = " + l.nombre);
                foreach (var tra in l.tramos)
                {
                    Console.WriteLine("    Tramo num = " + tra.numero + ", parada " + tra.parada.nombre);
                    foreach (var pre in tra.precio)
                    {
                        Console.WriteLine("        Precio id " + pre.id + " valor " + pre.valor);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("-------");
                Console.WriteLine("ERROR: " + e.Message);
                Console.WriteLine("-------");
            }

            Console.WriteLine("Fin de area de pruebas");
        }
    }
}
