using Microsoft.EntityFrameworkCore;
using Xamarin.Web.Data.Entities;

namespace Xamarin.Web.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Rol> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
