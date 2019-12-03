using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Xamarin.Web.Models
{
    public class MatterViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Name { get; set; }

        [Display(Name = "Carreras")]
        [Required(ErrorMessage = "Por favor, seleccioné una opción")]
        public string CareerId { get; set; }

        public IEnumerable<SelectListItem> Careers { get; set; }
    }
}
