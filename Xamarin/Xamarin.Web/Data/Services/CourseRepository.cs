using Xamarin.Web.Data.Entities;

namespace Xamarin.Web.Data
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(DataContext context) : base(context)
        {
        }
    }
}
