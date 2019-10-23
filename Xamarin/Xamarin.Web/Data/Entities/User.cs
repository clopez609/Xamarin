using System.ComponentModel.DataAnnotations;

namespace Xamarin.Web.Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(50)]
        [Required]
        public string Email { get; set; }

        [MaxLength(50)]
        [Required]
        public string Password { get; set; }

        public int? RolId { get; set; }
        public virtual Rol Rol { get; set; }

    }
}
