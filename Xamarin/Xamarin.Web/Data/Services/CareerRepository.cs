using Xamarin.Web.Data.Entities;
using Xamarin.Web.Data.Services;

namespace Xamarin.Web.Data
{
    public class CareerRepository : GenericRepository<Career>, ICareerRepository
    {
        public CareerRepository(DataContext context) : base(context)
        {

        }
    }
}
