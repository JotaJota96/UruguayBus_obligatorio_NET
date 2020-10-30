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

                    if (per == null)
                        return null;

                    //Persona personaRet = PersonaConverter.convert(per);
                    Usuario usuarioRet = UsuarioConverter.convert(per.usuario);
                    Persona personaRet = PersonaConverter.convert(per);
                    usuarioRet.persona = personaRet;
                    personaRet.usuario = usuarioRet;

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
                var res = new List<VehiculoCercanoDTO>();
                var parada = db.parada.FirstOrDefault(x=>x.id==idParada);
                if (parada == null)
                    throw new Exception("No se encontro ninguna parada con ese ID");

                var Res = db.viaje
                    .Where(x => x.finalizado == false).ToList()?
                    .Where(x=> x.horario.linea.tramo.Any(y=>y.parada_id == idParada) &&
                        !x.paso_por_parada.Any(y=>y.parada_id == idParada) &&
                        x.paso_por_parada.Any(y => y.parada_id == GetParadaAnterior(x.horario.linea.id, idParada))
                ).ToList()
                .Select(x=>
                    new VehiculoCercanoDTO() {
                        vehiculo_id = x.horario.vehiculo.id,
                        pasaje_reservado = idUsuario == null? false : x.pasaje.Any(y=>y.usuario.id == idUsuario)
                    }
                ).ToList();
            }
            return null;
        }

        private int GetParadaAnterior(int idlinea, int? idParada)
        {
            DAL_Global DAL_G = new DAL_Global();
            var paradas = DAL_G.obtenerParadasDeLinea(idlinea).Select(x=> ParadaConverter.convert(x)).ToList();
            parada ParadaAnterior = null;
            foreach (var parada in paradas)
            {
                if (parada.id != idParada)
                {
                    return ParadaAnterior != null ? ParadaAnterior.id : 0;
                } else
                {
                    ParadaAnterior = parada;
                }
            }
            return ParadaAnterior != null ? ParadaAnterior.id : 0;
        }

        private bool ParadasOrdenadas(int idlinea, int idParadaOrigen, int idParadaDestino)
        {

            DAL_Global DAL_G = new DAL_Global();
            var paradas = DAL_G.obtenerParadasDeLinea(idlinea).Select(x => ParadaConverter.convert(x)).ToList();
            bool? encontroParada = null;
            foreach (var parada in paradas)
            {
                if (parada.id == idParadaOrigen && encontroParada == null)
                {
                    encontroParada = false;
                } else if (parada.id == idParadaDestino && encontroParada == false)
                {
                    return true;
                }
            }
            return encontroParada?? false;
        }

        private decimal PrecioRecorrido(int idlinea, int idParadaOrigen, int idParadaDestino, DateTime fecha)
        {
            DAL_Global DAL_G = new DAL_Global();
            var paradas = DAL_G.obtenerParadasDeLinea(idlinea).Select(x => ParadaConverter.convert(x)).ToList();
            decimal precio = 0;
            bool EstoyEnRecorrido = false;
            foreach (var parada in paradas)
            {
                if (EstoyEnRecorrido)
                {
                    var valor = parada.tramo
                        .FirstOrDefault(x=>x.linea.id==idlinea)?.precio
                        .OrderByDescending(x => x.fecha_validez)
                        .FirstOrDefault(x=>x.fecha_validez.Date <= fecha.Date)?.valor?? 0;
                    precio += valor;
                    if (parada.id == idParadaDestino)
                    {
                        return precio;
                    }
                }
                else if (parada.id == idParadaOrigen)
                {
                    EstoyEnRecorrido = true;
                }
            }
            return precio;
        }

        private List<int> ParadasIntermedias(int idlinea, int idParadaOrigen, int idParadaDestino)
        {
            DAL_Global DAL_G = new DAL_Global();
            var res = new List<int>();
            var paradas = DAL_G.obtenerParadasDeLinea(idlinea);
            bool comienzo = false;
            foreach (var parada in paradas)
            {
                if (parada.id == idParadaOrigen)
                {
                    comienzo = true;
                }
                if (comienzo)
                {
                    res.Add(parada.id);
                }
                if (comienzo && parada.id == idParadaDestino)
                {
                    return res;
                }
            };
            return res;
        }
        private List<int> GetCantAsientosDisponiblies(viaje Viaje, int idParadaOrigen, int idParadaDestino)
        {
            DAL_Global DAL_G = new DAL_Global();
            var paradas = DAL_G.obtenerParadasDeLinea(Viaje.horario.linea.id).Select(x => ParadaConverter.convert(x)).ToList();
            var res = new List<int>();
            List<int> ParadasI = ParadasIntermedias(Viaje.horario.linea.id, idParadaOrigen, idParadaDestino);
            for (int i = 1; i < Viaje.horario.vehiculo.cant_asientos; i++)
            {
                var pasajesParaElAsiento = Viaje.pasaje.Where(x=>x.asiento==i).ToList();
                if (pasajesParaElAsiento.Count() == 0)
                {
                    res.Add(i);
                }
                else
                {
                    var asientoDisponible = true;
                    foreach (var pasaje in pasajesParaElAsiento)
                    {
                        if (ParadasI.Intersect(ParadasIntermedias(Viaje.horario.linea.id, pasaje.parada_id_origen, pasaje.parada_id_destino)).Count() == 0)
                        {
                            continue;
                        }
                        asientoDisponible = pasaje.parada_id_destino == idParadaOrigen ||
                            pasaje.parada_id_origen == idParadaDestino;
                        if (!asientoDisponible)
                        {
                            break;
                        }
                    }
                    if (asientoDisponible)
                    {
                        res.Add(i);
                    }
                }
            }
            return res;
        }
        public ICollection<ViajeDisponibleDTO> ListarViajesDisponibles(DateTime fecha, int idParadaOrigen, int idParadaDestino)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                DAL_Global DAL_G = new DAL_Global();
                var viajes = db.viaje
                    .Where(x => x.finalizado != true &&
                        x.horario.linea.tramo.Any(y => y.parada_id == idParadaOrigen) &&
                        x.horario.linea.tramo.Any(y => y.parada_id == idParadaDestino) &&
                        !x.paso_por_parada.Any(y => y.parada_id == idParadaOrigen)).ToList();
                viajes = viajes
                    .Where(x =>
                        ParadasOrdenadas(x.horario.linea.id, idParadaOrigen, idParadaDestino) &&
                        x.fecha.Date == fecha.Date)
                    .ToList();

                var res = viajes.Select(x => new ViajeDisponibleDTO() {
                    viaje_id = x.id,
                    linea_nombre = x.horario.linea.nombre,
                    parada_id_destino = idParadaDestino,
                    parada_id_origen = idParadaOrigen,
                    hora = x.horario.hora,
                    precio = PrecioRecorrido(x.horario.linea.id, idParadaOrigen, idParadaDestino, fecha),
                    asientos_disponibles = GetCantAsientosDisponiblies(x,idParadaOrigen, idParadaDestino)
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
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    if (db.persona.Where(x => x.correo == u.persona.correo).Count() != 0)
                        throw new Exception("Ya existe un usuario con ese correo");

                    usuario usu = UsuarioConverter.convert(u);
                    persona per = PersonaConverter.convert(u.persona);

                    usu.persona = per;
                    per.usuario = usu;

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
                try
                {
                    var viaje = db.viaje.FirstOrDefault(x => x.id == idViaje);

                    if (viaje == null)
                        throw new Exception("No se encontro ningun viaje con ese ID");

                    if (viaje.horario.linea.tramo.Any(t => t.parada.id == idParadaOrigen) && viaje.horario.linea.tramo.Any(t => t.parada.id == idParadaDestino))
                    {
                        int no = viaje.horario.linea.tramo.Where(t => t.parada.id == idParadaOrigen).First().numero;
                        int nd = viaje.horario.linea.tramo.Where(t => t.parada.id == idParadaDestino).First().numero;
                        if (no >= nd)
                            throw new Exception("La parada de origen es posterior a la de destino");
                    }
                    else
                    {
                        throw new Exception("Una o ambas paradas no pertenecen a la linea");
                    }

                    var parada = db.parada.FirstOrDefault(x => x.id == idParadaOrigen);
                    var parada1 = db.parada.FirstOrDefault(x => x.id == idParadaDestino);
                    var usuario = db.usuario.FirstOrDefault(x => x.id == idUsuario);

                    if (usuario == null)
                        throw new Exception("No se encontro ningun usuario con ese ID");

                        var pasaje = new pasaje()
                    {
                        parada = parada,
                        parada_id_destino = idParadaDestino,
                        parada_id_origen = idParadaOrigen,
                        parada1 = parada1,
                        viaje_id = idViaje,
                        viaje = viaje,
                        usuario_id = idUsuario,
                        usuario = usuario,
                        asiento = asiento,
                    };
                    db.pasaje.Add(pasaje);
                    db.SaveChanges();
                    return PasajeConverter.convert(pasaje);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public Pasaje ReservarPasaje(int idViaje, int idParadaOrigen, int idParadaDestino, string documento, TipoDocumento tipoDocumento, int? asiento = null)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    var viaje = db.viaje.FirstOrDefault(x=>x.id==idViaje);

                    if (viaje == null)
                        throw new Exception("No se encontro ningun viaje con ese ID");

                    if (viaje.horario.linea.tramo.Any(t => t.parada.id == idParadaOrigen) && viaje.horario.linea.tramo.Any(t => t.parada.id == idParadaDestino))
                    {
                        int no = viaje.horario.linea.tramo.Where(t => t.parada.id == idParadaOrigen).First().numero;
                        int nd = viaje.horario.linea.tramo.Where(t => t.parada.id == idParadaDestino).First().numero;
                        if (no >= nd)
                            throw new Exception("La parada de origen es posterior a la de destino");
                    }
                    else
                    {
                        throw new Exception("Una o ambas paradas no pertenecen a la linea");
                    }


                    var parada = db.parada.FirstOrDefault(x=> x.id == idParadaOrigen);
                    var parada1 = db.parada.FirstOrDefault(x => x.id == idParadaDestino);
                    var pasaje = new pasaje() {
                        //parada_id_destino = idParadaDestino,
                        parada = parada,
                        //parada_id_origen = idParadaOrigen,
                        parada1 = parada1,
                        //viaje_id = idViaje,
                        viaje = viaje,
                        tipo_documento = tipoDocumento == TipoDocumento.CI ? 0:1,
                        documento = documento,
                        asiento = asiento,
                    };
                    db.pasaje.Add(pasaje);
                    db.SaveChanges();
                    return PasajeConverter.convert(pasaje);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
