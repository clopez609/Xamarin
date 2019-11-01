using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Xamarin.Web.Data.Entities;

namespace Xamarin.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Career> Careers { get; set; }
        public DbSet<Matter> Matters { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
