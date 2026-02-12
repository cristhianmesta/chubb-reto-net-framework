using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ChubbReto.Web.Models
{
    public class CreateBookViewModel
    {
        [Required(ErrorMessage = "El título es obligatorio")]
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Required(ErrorMessage = "El año es obligatorio")]
        [Display(Name = "Año")]
        [RegularExpression(@"^(19|20)\d{2}$", ErrorMessage = "Ingrese un año válido (1900-2099)")]
        public int Year { get; set; }

        [Display(Name = "Género")]
        public int? GenreId { get; set; }

        [Display(Name = "Número de páginas")]
        [Range(1, int.MaxValue, ErrorMessage = "El número de páginas debe ser mayor a 0")]
        public int? NumberOfPages { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un autor")]
        [Display(Name = "Autor")]
        public int AuthorId { get; set; }

        public IEnumerable<SelectListItem> Authors { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }
    }
}