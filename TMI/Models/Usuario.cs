using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TMI.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(30, ErrorMessage = "El nombre excede el numero maximo de caracteres (30). Ingrese uno más corto por favor)")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [MaxLength(10, ErrorMessage = "El apellido excede el numero maximo de caracteres (30). Ingrese uno más corto por favor)")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Debe ingresar un mail válido")]
        [MaxLength(30, ErrorMessage = "El correo excede el numero maximo de caracteres (30). Ingrese uno más corto por favor)")]
        public string Email { get; set; }

        public DateTime FechaRegistro { get; set; }
    }
}