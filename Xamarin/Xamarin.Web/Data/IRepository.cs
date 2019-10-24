using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Web.Data.Entities;

namespace Xamarin.Web.Data
{
    public interface IRepository
    {
        void AddUser(User User);

        User GetUser(int id);

        IEnumerable<User> GetUsers();

        void RemoveUser(User User);

        Task<bool> SaveAllAsync();

        void UpdateUser(User User);

        bool UserExists(int id);
    }
}