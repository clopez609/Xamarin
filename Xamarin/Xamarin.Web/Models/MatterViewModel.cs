using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Xamarin.Web.Models
{
    public class MatterViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }

        [Display(Name = "Carreras")]
        [Required(ErrorMessage = "Seleccioné una opción, por favor")]
        public string CareerId { get; set; }

        public IEnumerable<SelectListItem> Careers { get; set; }
    }
}
