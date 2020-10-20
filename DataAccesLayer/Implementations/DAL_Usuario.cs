using DataAccesLayer.Converters;
using DataAccesLayer.Interfaces;
using Share.DTOs;
using Share.Entities;
using Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Implementations
{
    public class DAL_Usuario : IDAL_Usuario
    {
        public Usuario IniciarSesion(string correo, string contrasenia) {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    var per = db.persona
                        .FirstOrDefault(x=>
                            x.correo == correo &&
                            x.contrasenia==contrasenia);

                    //Persona personaRet = PersonaConverter.convert(per);
                    Usuario usuarioRet = UsuarioConverter.convert(per.usuario);

                    return usuarioRet;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public List<VehiculoCercanoDTO> ListarVehiculosCercanos(int idParada, int? idUsuario = null)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                //.Where(x => x.fecha.Date == DateTime.Now.Date).ToList()
                var res = new List<VehiculoCercanoDTO>();
                var parada = db.parada.FirstOrDefault(x=>x.id==idParada);
                var Viajes = db.viaje
                    .Where(x => x.finalizado == false).ToList()?
                    .Where(x=> x.horario.linea.tramo.Any(y=>y.parada_id == idParada))
                    .ToList();
                var algo = Viajes
                    .Where(x =>
                        !x.paso_por_parada.Any(y=>y.parada_id == idParada) &&
                        !x.paso_por_parada.Any(y => y.parada_id == idParada)
                ).ToList();
            }
            return null;
        }

        private List<linea> GetLineasParada()
        {
            return null;
        }

        public ICollection<ViajeDisponibleDTO> ListarViajesDisponibles(DateTime fecha, int idParadaOrigen, int idParadaDestino)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                var res = new List<ViajeDisponibleDTO>();
                var viajes = db.viaje.Where(x=>x.finalizado == false).ToList();
                viajes = viajes
                    .Where(x =>
                        x.paso_por_parada.Any(y => y.parada_id == idParadaDestino || y.parada_id == idParadaOrigen) &&
                        x.fecha.Date == fecha.Date)
                    .ToList();
                res = viajes.Select(x => new ViajeDisponibleDTO() {
                    viaje_id = x.id,
                    parada_id_destino = idParadaDestino,
                    parada_id_origen = idParadaOrigen,
                    hora = x.horario.hora,
                }).ToList();
                return res;
            }
        }

        public decimal PrecioParaElegirAsiento()
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    var Precio = db.parametro.FirstOrDefault(x=>x.nombre== "PrecioMinimo");

                    if (Precio!=null)
                    {
                        return Precio.valor;
                    } else {
                        return 0;
                    }

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public Usuario RegistrarUsuario(Usuario u)
        {
            usuario usu = UsuarioConverter.convert(u);
            persona per = PersonaConverter.convert(u.persona);

            usu.persona = per;
            per.usuario = usu;

            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    db.persona.Add(per);
                    db.SaveChanges();

                    Persona personaRet = PersonaConverter.convert(per);
                    Usuario usuarioRet = UsuarioConverter.convert(usu);

                    personaRet.usuario = usuarioRet;
                    usuarioRet.persona = personaRet;

                    return usuarioRet;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public Pasaje ReservarPasaje(int idViaje, int idParadaOrigen, int idParadaDestino, int idUsuario, int? asiento = null)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                var viaje = db.viaje.FirstOrDefault(x => x.id == idViaje);
                var parada = db.parada.FirstOrDefault(x => x.id == idParadaOrigen);
                var parada1 = db.parada.FirstOrDefault(x => x.id == idParadaDestino);
                var usuario = db.usuario.FirstOrDefault(x => x.id == idUsuario);
                if (viaje != null)
                {
                    var pasaje = new pasaje()
                    {
                        parada_id_destino = idParadaDestino,
                        parada = parada,
                        parada_id_origen = idParadaOrigen,
                        parada1 = parada1,
                        viaje_id = idViaje,
                        viaje = viaje,
                        usuario_id = idUsuario,
                        usuario = usuario,
                        asiento = asiento,
                        //tipo_documento = usuario.persona.tipo_documento,
                        //documento = usuario.persona.documento,
                    };
                }
                return null;
            }
        }

        public Pasaje ReservarPasaje(int idViaje, int idParadaOrigen, int idParadaDestino, string documento, TipoDocumento tipoDocumento, int? asiento = null)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                var viaje = db.viaje.FirstOrDefault(x=>x.id==idViaje);
                var parada = db.parada.FirstOrDefault(x=> x.id == idParadaOrigen);
                var parada1 = db.parada.FirstOrDefault(x => x.id == idParadaDestino);
                if (viaje != null)
                {
                    var pasaje = new pasaje() {
                    parada_id_destino = idParadaDestino,
                    parada = parada,
                    parada_id_origen = idParadaOrigen,
                    parada1 = parada1,
                    viaje_id = idViaje,
                    viaje = viaje,
                    tipo_documento = tipoDocumento == TipoDocumento.CI ? 0:1,
                    documento = documento,
                    asiento = asiento,
                    };
                }
                return null;
            }
        }
    }
}
