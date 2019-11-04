using Xamarin.Web.Data.Entities;

namespace Xamarin.Web.Data
{
    public class CareerRepository : GenericRepository<Career>, ICareerRepository
    {
        public CareerRepository(DataContext context) : base(context)
        {

        }
    }
}
