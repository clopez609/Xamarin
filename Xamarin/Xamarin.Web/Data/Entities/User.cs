using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Xamarin.Web.Data.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public string LastName { get; set; }
    }
}
