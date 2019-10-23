using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Web.Data.Entities;

namespace Xamarin.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext context;
        private Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Roles.Any())
            {
                this.AddRol("Admin");
                this.AddRol("Alumno");
                this.AddRol("Profesor");
                await this.context.SaveChangesAsync();
            }

        }

        private void AddRol(string name)
        {
            this.context.Roles.Add(new Rol
            {
                Name = name,
            });
        }
    }
}
