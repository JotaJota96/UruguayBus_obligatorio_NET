using Share.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using UruguayBusWeb.Models;

namespace UruguayBusWeb.Helpers
{
    public class EmailHelper
    {
        HttpClient client = new HttpClient();

        /// <summary>
        /// Inicializa los datos de la peticion
        /// </summary>
        public EmailHelper()
        {
            string api_url = ConfigurationManager.AppSettings["SendinBlueUrlSendMail"];
            string api_key = ConfigurationManager.AppSettings["SendinBlueApiKey"];

            client.BaseAddress = new Uri(api_url);
            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("accept", "application/json");
            client.DefaultRequestHeaders.Add("api-key", api_key);
        }

        /// <summary>
        /// Envia un correo con el pasaje reservado al usuario especificado
        /// </summary>
        /// <param name="u">Usuario al que se le envia el correo</param>
        /// <param name="p">Pasaje a enviar en el correo</param>
        public void EnviarPasajeReservado(Usuario u, Pasaje p, ConfirmarPagoModel cpm)
        {
            try
            {
                // obtengo el pasaje en PDF en base64
                string pdfBase64 = new PdfHelper().GenerarPasaje(u, p, cpm);

                // crea el correo para enviar
                EmailDTO email = new EmailDTO()
                {
                    // datos de quien envia
                    sender = new EmailInvolvedDTO()
                    {
                        email = ConfigurationManager.AppSettings["SendinBlueMailSenderEmail"],
                        name = ConfigurationManager.AppSettings["SendinBlueMailSenderName"],
                    },
                    // asunto
                    subject = ConfigurationManager.AppSettings["SendinBlueMailSubject"],
                    // contenido html (ya no lo uso porque uso un template)
                    //htmlContent = emailHtml,

                    // ID del template a usar
                    templateId = 1,
                };

                // Establesco la lista de destinatarios (que en realidad es uno solo)
                email.to.Add(
                    new EmailInvolvedDTO()
                    {
                        email = u.persona.correo,
                        name = u.persona.nombre,
                    }
                );

                //agrego el archivo adjunto
                email.attachment.Add(
                    new EmailAttachmentBase64DTO()
                    {
                        name = "pasaje_" + p.id + ".pdf",
                        content = pdfBase64,
                    }
                );

                //agrego los parametros que se usan en el template
                email.@params.Add("nombre", u.persona.nombre);

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(email);

                // envio la peticion HTTP con los datos a la API de SendinBlue
                HttpResponseMessage response = Task.Run(() => client.PostAsJsonAsync("smtp/email", email)).Result;
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error al enviar el correo. " + e.Message);
            }

        }
    }

    // **** **** **** Objetos de ayuda **** **** **** **** ****

    class EmailDTO
    {
        public EmailInvolvedDTO sender { get; set; } = new EmailInvolvedDTO();
        public ICollection<EmailInvolvedDTO> to { get; set; } = new List<EmailInvolvedDTO>();
        public string subject { get; set; }
        //public string htmlContent { get; set; }
        public int templateId { get; set; }
        public ICollection<EmailAttachmentBase64DTO> attachment { get; set; } = new List<EmailAttachmentBase64DTO>();
        public IDictionary<string, string> @params { get; set; } = new Dictionary<string, string>();
    }

    class EmailInvolvedDTO
    {
        public string email { get; set; }
        public string name { get; set; }
    }

    class EmailAttachmentBase64DTO
    {
        public string name { get; set; }
        public string content { get; set; }
    }

}