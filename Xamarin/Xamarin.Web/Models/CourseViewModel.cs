using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Xamarin.Web.Models
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public IEnumerable<SelectListItem> Days = new SelectList(new List<SelectListItem>
        {
            new SelectListItem {  Text = "Lunes 18-22hs", Value = "1"},
            new SelectListItem {  Text = "Martes 18-22hs", Value = "2"},
            new SelectListItem {  Text = "Miercoles 18-22hs", Value = "3" },
            new SelectListItem {  Text = "Jueves 18-22hs", Value = "4" },
            new SelectListItem {  Text = "Viernes 18-22hs", Value = "5" },

        });
    }
}
