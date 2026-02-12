using System;
using System.ComponentModel.DataAnnotations;

namespace ChubbReto.Web.Models
{
    public class CreateAuthorViewModel
    {
        [Required(ErrorMessage = "El nombre completo es obligatorio")]
        [Display(Name = "Nombre Completo")]
        [StringLength(250)]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaDeNacimiento { get; set; }

        [Display(Name = "Ciudad de procedencia")]
        public string CiudadDeProcedencia { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        [Display(Name = "Correo electrónico")]
        public string CorreoElectronico { get; set; }
    }
}
