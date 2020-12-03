using iTextSharp.text;
using iTextSharp.text.pdf;
using Share.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace UruguayBusWeb.Helpers
{
    public class PdfHelper
    {


        public string GenerarPasaje(Usuario usuario, Pasaje pasaje)
        {
            // creo un documento
            Document doc = new Document(PageSize.A5, 18, 18, 16, 0);
            // creo un espacio en memoria para ir generando el documento
            MemoryStream ms = new MemoryStream();
            // creo un escritor de pdf pasandole el documento y el espacio de memoria
            PdfWriter writer = PdfWriter.GetInstance(doc, ms);

            // genero el codigo QR
            BarcodeQRCode qr = new BarcodeQRCode(pasaje.id.ToString(), 1000, 1000, null);
            // obtengo la imagen del QR
            Image imagenQR = qr.GetImage();
            // redimensiono la imagen
            imagenQR.ScaleAbsolute(200, 200);

            doc.Open();
            // creo el tipo de fuente
            // hay que pasarsela a cada parafo que se quiera escribir con ella
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.WINANSI, BaseFont.EMBEDDED);

            // defino la fuente para este parrafo
            Font fontText = new Font(bf, 20, 0, BaseColor.BLACK);
            // creo el parrafo
            Paragraph par1 = new Paragraph("Estimado pasajero, ha recibido su pasaje.", fontText);
            // alineacion centrada
            par1.Alignment = Element.ALIGN_CENTER;
            // agrego el parrafo al documento
            doc.Add(par1);

            Font fontText2 = new Font(bf, 15, 0, BaseColor.BLACK);
            Paragraph par0 = new Paragraph("UruguayBus 2020 le desea buen viaje.", fontText2);
            par0.Alignment = Element.ALIGN_CENTER;
            doc.Add(par0);

            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            doc.Add(p);

            DateTime ahora = DateTime.Now;
            ahora = ahora.Subtract(new TimeSpan(03, 0, 0)); // seteo tiempo a estedos unidos

            Paragraph paragraphs = new Paragraph(new Phrase("Enviado: " + ahora));
            paragraphs.Alignment = Element.ALIGN_RIGHT;
            doc.Add(paragraphs);

            doc.Add(new Paragraph("Pasajero: " + "NOMBRE" + " " + "APELLIDO"));
            doc.Add(new Paragraph("Documento: " + "DOCUMENTO"));

            doc.Add(new Paragraph("Linea: " + "linea"));
            doc.Add(new Paragraph("Origen: " + "orign"));
            doc.Add(new Paragraph("Destino: " + "destino"));
            doc.Add(new Paragraph("Salida: " + "fechaViaje" + " " + "hora"));
            doc.Add(new Paragraph("Matricula: " + "matricula"));

            doc.Add(new Paragraph("Costo: " + "costo" + " UYU"));

            //doc.Add(new Chunk("\n"));

            Paragraph p3 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            doc.Add(p3);

            Font fontText4 = new Font(bf, 10, 0, BaseColor.BLACK);
            doc.Add(new Paragraph("Presente el siguiente código QR al chofer.", fontText4));


            imagenQR.Alignment = Element.ALIGN_CENTER;
            doc.Add(imagenQR);

            writer.CloseStream = false;
            doc.Close();
            ms.Position = 0;

            string base64 = Convert.ToBase64String(ms.ToArray());

            return base64;
        }

    }
}