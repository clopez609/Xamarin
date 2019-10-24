using Microsoft.AspNetCore.Mvc;
using Xamarin.Web.Data;

namespace Xamarin.Web.Controllers.API
{
    [Route("api/[Controller]")]
    public class CoursesController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public IActionResult GetCourses()
        {
            return Ok(_courseRepository.GetAll());
        }
    }
}
