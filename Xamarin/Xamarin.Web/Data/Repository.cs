using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Web.Data.Entities;

namespace Xamarin.Web.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.OrderBy(p => p.Name);
        }

        public User GetUser(int id)
        {
            return _context.Users.Find(id);
        }

        public void AddUser(User User)
        {
            _context.Users.Add(User);
        }

        public void UpdateUser(User User)
        {
            _context.Users.Update(User);
        }

        public void RemoveUser(User User)
        {
            _context.Users.Remove(User);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(p => p.Id == id);
        }

    }
}
