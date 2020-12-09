using Share.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UruguayBusWeb.Models.Validators;

namespace UruguayBusWeb.Models
{
    public class RegistrarUsuarioModel
    {
        [DisplayName("Nombre")]
        [Required]
        [StringLength(20, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string nombre { get; set; }

        [DisplayName("Apellido")]
        [Required]
        [StringLength(20, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string apellido { get; set; }

        [DisplayName("Tipo de documento")]
        [Required]
        public TipoDocumento tipo_documento { get; set; }

        [DisplayName("Documento")]
        [Required]
        [StringLength(20, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string documento { get; set; }

        [DisplayName("Correo")]
        [Required]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [EmailAddress]
        [CorreoDisponible(ErrorMessage ="Ya hay un usuario registrado con ese correo")]
        public string correo { get; set; }

        [DisplayName("Contraseña")]
        [Required]
        [StringLength(20, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string contrasenia { get; set; }

        [DisplayName("Repetir")]
        [Required]
        [Compare("contrasenia", ErrorMessage ="Las contraseñas no coinciden")]
        public string contraseniaRepetir { get; set; }

    }

}