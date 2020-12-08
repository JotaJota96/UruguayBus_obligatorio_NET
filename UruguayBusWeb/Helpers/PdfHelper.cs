using iTextSharp.text;
using iTextSharp.text.pdf;
using Share.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using UruguayBusWeb.Models;

namespace UruguayBusWeb.Helpers
{
    public class PdfHelper
    {

        public string GenerarPasaje(Usuario usuario, Pasaje pasaje, ConfirmarPagoModel cpm)
        {
            // primero organizo los datos que se van a mostrar en el PDF
            // genero el QR
            Image imagenQR = this.generarQR(pasaje.id.ToString());
            // Información que se va a mostrar
            IDictionary<string, string> datos = new Dictionary<string, string>();
            datos.Add("Linea:", cpm.nombreLinea);
            datos.Add("Fecha y hora:", cpm.fecha.ToString("dd/MM/yyyy") + " " + cpm.hora.ToString(@"hh\:mm"));
            datos.Add("Origen:", cpm.nombreParadaOrigen);
            datos.Add("Destino:", cpm.nombreParadaDestino);
            datos.Add("Asiento:", cpm.asiento == 0 ? "Sin asiento" : cpm.asiento.ToString());
            datos.Add("Precio:", "$ " + cpm.precio);

            // ---------------------------------

            // creo un documento
            Document doc = new Document(PageSize.A5.Rotate(), 18, 18, 18, 18);
            // creo un espacio en memoria para ir generando el documento
            MemoryStream ms = new MemoryStream();
            // creo un escritor de pdf pasandole el documento y el espacio de memoria
            PdfWriter writer = PdfWriter.GetInstance(doc, ms);

            doc.Open();
            // creo el tipo de fuente
            // hay que pasarsela a cada parafo que se quiera escribir con ella
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.WINANSI, BaseFont.EMBEDDED);
            
            // agrego una linea horizontal arriba de todo
            doc.Add(new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.GRAY, Element.ALIGN_LEFT, 1))));

            // creo la tabla principal del pasaje
            PdfPTable tabla = new PdfPTable(4); // 4 columnas

            PdfPCell celdaQR = new PdfPCell(imagenQR) {
                Border = 0,
                HorizontalAlignment = 1,
            };
            // agrego la celda a la tabla principal
            tabla.AddCell(celdaQR);


            // creo una tabla con los detalles del pasaje
            // esta tabla estará contenida dentro de una celda al lado del codigo QR
            PdfPTable tablaDetalles = new PdfPTable(4);
            // agrego datos a esta tabla
            foreach (var item in datos)
            {
                tablaDetalles.AddCell(new PdfPCell(new Phrase(item.Key)) { Border = 0 });
                tablaDetalles.AddCell(new PdfPCell(new Phrase(item.Value)) { Colspan = 3, Border = 0 });
            }
            // creo una la celda para la tabla que llené recien, y esa celda la agrego a la tabla principal
            tabla.AddCell(new PdfPCell(tablaDetalles) {
                Colspan = 3,
                Border = 0,
            });

            // agrego la tabla principal al documento
            doc.Add(tabla);

            // agrego una linea horizontal abajo de todo
            doc.Add(new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.GRAY, Element.ALIGN_LEFT, 1))));

            // finalizo el documento
            writer.CloseStream = false;
            doc.Close();
            ms.Position = 0;

            // convierto el documento a Base64 y lo retorna
            return Convert.ToBase64String(ms.ToArray());
        }

        private Image generarQR(string contenido, int ancho = 100, int alto = 100)
        {
            // genero el codigo QR
            BarcodeQRCode qr = new BarcodeQRCode(contenido, 1000, 1000, null);
            // obtengo la imagen del QR
            Image imagenQR = qr.GetImage();
            // redimensiono la imagen
            imagenQR.ScaleAbsolute(ancho, alto);
            return imagenQR;
        }
    }

}