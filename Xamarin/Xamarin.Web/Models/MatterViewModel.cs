using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Web.Data.Entities;

namespace Xamarin.Web.Models
{
    public class MatterViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Carreras")]
        [Required(ErrorMessage = "Por favor, seleccione una opción")]
        public string CareerId { get; set; }

        public IEnumerable<SelectListItem> Careers { get; set; }
    }
}
