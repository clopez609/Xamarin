using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
