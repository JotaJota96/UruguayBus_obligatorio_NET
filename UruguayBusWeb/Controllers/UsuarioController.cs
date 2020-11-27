﻿using MercadoPago.Common;
using MercadoPago.DataStructures.Payment;
using MercadoPago.Resources;
using Share.DTOs;
using Share.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UruguayBusWeb.ApiClient;
using UruguayBusWeb.Models;
using UruguayBusWeb.Models.Proxy;

namespace UruguayBusWeb.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioProxy up = new UsuarioProxy();
        GlobalProxy gp = new GlobalProxy();

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        // **** **** Inicio de seccion de Juan **** ****

        // GET: Usuario/ComprarPasaje
        public async Task<ActionResult> ComprarPasaje()
        {
            ComprarPasajeModel cpm = new ComprarPasajeModel();
            cpm.fecha = DateTime.Today;
            cpm.lineas = (List<Share.Entities.Linea>) await gp.ListarLinea();
            cpm.precioElegirAsiento = await up.PrecioParaElegirAsiento();

            return View(cpm);
        }

        // POST: Usuario/ComprarPasaje
        [HttpPost]
        public async Task<ActionResult> ComprarPasaje(ComprarPasajeModel cpm)
        {
            try
            {
                cpm.lineas = (List<Share.Entities.Linea>)await gp.ListarLinea();
                cpm.precioElegirAsiento = await up.PrecioParaElegirAsiento();

                // calidacion
                if ( ! TryValidateModel(cpm, nameof(ComprarPasaje))){
                    return View(cpm);
                }

                ConfirmarPagoModel confPago = new ConfirmarPagoModel()
                {
                    fecha               = cpm.fecha,
                    idViaje             = cpm.idViaje,
                    idLinea             = cpm.idLinea,
                    idParadaOrigen      = cpm.idParadaOrigen,
                    idParadaDestino     = cpm.idParadaDestino,
                    asiento             = cpm.asiento,
                    precio              = cpm.precio,
                    nombreLinea         = Task.Run(() => gp.obtenerLinea(cpm.idLinea)).Result.nombre,
                    nombreParadaOrigen  = Task.Run(() => gp.obtenerParada(cpm.idParadaOrigen)).Result.nombre,
                    nombreParadaDestino = Task.Run(() => gp.obtenerParada(cpm.idParadaDestino)).Result.nombre,
                };

                return View("ConfirmarPago", confPago);
            }
            catch (Exception)
            {
                return View(cpm);
            }
        }


        // POST: Usuario/ListarParadasDeLineaAjax
        [HttpPost]
        public async Task<JsonResult> ListarParadasDeLineaAjax(int id)
        {
            try
            {
                ICollection<Parada> paradas = await gp.obtenerParadasDeLinea(id);

                List<SelectListItem> lstRet = paradas
                    .Select(x => new SelectListItem()
                    {
                        Text = "" + x.nombre,
                        Value = "" + x.id
                    }).ToList();
                return Json(lstRet, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new List<SelectListItem>(), JsonRequestBehavior.AllowGet);
            }
        }



        // POST: Usuario/BuscarViajesAjax
        [HttpPost]
        public async Task<JsonResult> BuscarViajesAjax(DateTime fecha, int idLinea, int idParadaOrigen, int idParadaDestino)
        {
            try
            {
                ICollection<ViajeDisponibleDTO> vd = (await up.ListarViajesDisponibles(fecha, idParadaOrigen, idParadaDestino))
                    .Where(x => x.linea_id == idLinea)
                    .OrderBy(x => x.hora)
                    .ToList();
                foreach (var item in vd)
                {
                    item.horaStr = item.hora.ToString(@"hh\:mm");
                }
                return Json(vd, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new List<SelectListItem>(), JsonRequestBehavior.AllowGet);
            }
        }


        // POST: Usuario/ConfirmarPago
        [HttpPost]
        public async Task<ActionResult> ConfirmarPago(ConfirmarPagoModel cpm)
        {
            Pasaje pasaje = new Pasaje();
            try
            {
                // Pseudocodigo:
                // obtener datos del usuario y de pasaje a reservar
                // Realizar la reserva
                // Verificar el estado del pago, si es correcto:
                //     mostrar mensaje ok
                // si no:
                //     cancelar la reserva
                //     mostrar mensaje error

                // obtengo al usuario logueado
                Usuario u = (Usuario) Session["datosLogeados"];

                // completo los datos necesarios para reservar
                ReservarPasajeDTO rpdto = new ReservarPasajeDTO()
                {
                    idViaje = cpm.idViaje,
                    idParadaOrigen = cpm.idParadaOrigen,
                    idParadaDestino = cpm.idParadaDestino,
                    asiento = cpm.asiento,
                    idUsuario = u.id,
                    documento = u.persona.documento,
                    tipoDocumento = u.persona.tipo_documento,
                };

                // realizo la reserva, si falla, en el catch la cancelo
                pasaje = await up.ReservarPasaje(rpdto);

                // creo un objeto Pago con la informacion necesaria
                Payment payment = new Payment()
                {
                    TransactionAmount = (float?) cpm.precio,
                    Token = cpm.token,
                    Description = "Reserva de pasaje en UruguayBus",
                    Installments = cpm.installments,
                    PaymentMethodId = cpm.payment_method_id,
                    IssuerId = cpm.issuer_id,
                    Payer = new Payer()
                    {
                        Email = ConfigurationManager.AppSettings["UnobtrusivePayerEmail"],
                    }
                };

                // confirma el pago
                payment.Save();

                /**
                 * pending      => El usuario no completo el proceso de pago todavía.
                 * approved     => El pago fue aprobado y acreditado.
                 * authorized   => El pago fue autorizado pero no capturado todavía.
                 * in_process   => El pago está en revisión.
                 * in_mediation => El usuario inició una disputa.
                 * rejected     => El pago fue rechazado.El usuario podría reintentar el pago.
                 * cancelled    => El pago fue cancelado por una de las partes o el pago expiró.
                 * refunded     => El pago fue devuelto al usuario.
                 * charged_back => Se ha realizado un contracargo en la tarjeta de crédito del comprador
                 */

                // verifico el estado del pago
                if (payment.Status == PaymentStatus.approved)
                { // todo bien
                    cpm.accion = ConfirmarPagoResult.Ok;
                }
                else
                {
                    cpm.accion = ConfirmarPagoResult.Error;
                    await up.CancelarPasaje(pasaje.id);
                }
                return View(cpm);
            }
            catch (Exception e)
            {
                try
                {
                    await up.CancelarPasaje(pasaje.id);
                }
                catch (Exception)
                {
                }
                cpm.accion = ConfirmarPagoResult.Error;
                return View(cpm);
            }
        }

        // **** **** Fin de seccion de Juan **** ****
        // **** **** Inicio de seccion de Sebastian **** ****

        // **** **** Fin de seccion de Sebastian **** ****
        // **** **** Inicio de seccion de Lucas **** ****

        // **** **** Fin de seccion de Lucas **** ****

    }
}