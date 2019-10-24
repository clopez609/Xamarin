using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Xamarin.Web.Data.Entities;

namespace Xamarin.Web.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);
    }
}
