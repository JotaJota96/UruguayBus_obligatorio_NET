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

namespace BusinessLayer.Implementations
{
    public class BL_Admin : IBL_Admin
    {
        private IDAL_Admin dal = new DAL_Admin();
        private IDAL_Global dalg = new DAL_Global();

        public BL_Admin()
        {
            //
        }

        public ICollection<Parada> ListarParadas()
        {
            try
            {
                return dal.ListarParadas();
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un problema al intentar obtener el listado. " + e.Message);
            }
        }

        public Vehiculo ModificarVehiculo(Vehiculo v)
        {
            try
            {
                return dal.ModificarVehiculo(v);
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un problema al intentar modificar el vehiculo. " + e.Message);
            }
        }

        public Horario RegistrarHorario(Horario h)
        {
            try
            {
                if (h.vehiculo == null)  throw new Exception("El horario debe estar asociado a un vehiculo");
                if (h.conductor == null) throw new Exception("El horario debe estar asociado a un conductor");
                if (h.linea== null)      throw new Exception("El horario debe estar asociado a una linea");

                return dal.RegistrarHorario(h);
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un problema al intentar registrar el horario. " + e.Message);
            }
        }

        public Linea RegistrarLinea(Linea l)
        {
            /// Registra una nueva linea en el sistema, sus respectivos tramos, y el precio de cada tramo
            /// Vinculos esperados: La linea debe estar vinculada a los tramos, cada tramo a una parada, cada precio a un tramo
            try
            {
                if (l == null) throw new Exception("Debe especificar una linea");
                if (l.tramos.Count < 2) throw new Exception("La linea debe estar formada por al menos 2 paradas (tramos).");
                ICollection<int> numeros = new List<int>();


                // para cada tramo verifico:
                // que tenga una parada asociada
                // que el numero de tramo no se repita
                // que tenga un precio asociado
                foreach (var t in l.tramos)
                {
                    if (t == null) throw new Exception("Hay un tramo = null");
                    if (t.parada == null) throw new Exception("Se encontró un tramo sin parada asociada.");
                    
                    if (numeros.Contains(t.numero))
                    {
                        throw new Exception("Hay dos paradas con el mismo numero.");
                    }
                    else
                    {
                        numeros.Add(t.numero);
                    }

                    if (t.precio.Count < 1)
                    {
                        throw new Exception("No puede haber un tramo sin precio asociado.");
                    }
                }

                return dal.RegistrarLinea(l);
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un problema al intentar registrar la linea. " + e.Message);
            }
        }

        public Parada RegistrarParada(Parada p)
        {
            try
            {
                return dal.RegistrarParada(p);
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un error al intentar registrar la parada. " + e.Message);
            }
        }

        public Vehiculo RegistrarVehiculo(Vehiculo v)
        {
            try
            {
                return dal.RegistrarVehiculo(v);
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un error al intentar registrar el vehiculo. " + e.Message);
            }
        }

        public ICollection<Viaje> RegistrarViajes(int idHorario, DateTime fInicio, DateTime fFin, ICollection<DiaSemana> dias)
        {
            try
            {
                ICollection<Viaje> viajes = new List<Viaje>();

                if (fInicio.CompareTo(fFin) >= 0)
                {
                    throw new Exception("La fecha de inicio debe ser anterior que la de fin");
                }
                if (dias.Count < 1)
                {
                    throw new Exception("Se debe especificar al menos un dia de la semana");
                }

                for (; fInicio.CompareTo(fFin) <= 0; fInicio = fInicio.AddDays(1))
                {
                    if (dias.Contains((DiaSemana)fInicio.DayOfWeek))
                    {
                        viajes.Add(new Viaje()
                        {
                            fecha = fInicio,
                            finalizado = null,
                        });
                    }
                }

                return dal.RegistrarViajes(viajes, idHorario);
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un error al intentar registrar los viajes. " + e.Message);
            }
        }
    }
}
