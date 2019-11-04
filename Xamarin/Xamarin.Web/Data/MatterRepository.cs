using Xamarin.Web.Data.Entities;

namespace Xamarin.Web.Data
{
    public class MatterRepository : GenericRepository<Matter>, IMatterRepository
    {
        public MatterRepository(DataContext context) : base(context)
        {
        }
    }
}
