using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Web.Data;
using Xamarin.Web.Data.Entities;
using Xamarin.Web.Helpers;
using Xamarin.Web.Models;

namespace Xamarin.Web.Controllers
{

    public class MattersController : Controller
    {
        private readonly ICareerRepository _careerRepository;
        private readonly IMatterRepository _matterRepository;
        private readonly IUserHelper _userHelper;
        public MattersController(
            ICareerRepository careerRepository,
            IMatterRepository matterRepository,
            IUserHelper userHelper)
        {
            _careerRepository = careerRepository;
            _matterRepository = matterRepository;
            _userHelper = userHelper;
        }

        public IActionResult Index()
        {
            return View(_matterRepository.GetAll());
        }

        public IActionResult Create()
        {
            var vm = new MatterViewModel
            {
                Careers = _careerRepository.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                }).ToList()
            };

            return PartialView("_CreatePartial", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MatterViewModel vm)
        {
            if (vm != null && ModelState.IsValid)
            {
                var matter = new Matter
                {
                    Name = vm.Name,
                    CarrerId = Convert.ToInt32(vm.CareerId)
                };

                await _matterRepository.CreateAsync(matter);

                return Json(new
                {
                    status = 200,
                    url = Url.Action("Index", "Matters")
                });
            }
            else
            {
                var errorList = ModelState.ToDictionary(
                                    kvp => kvp.Key,
                                    kvp => kvp.Value.Errors
                                    .Select(e => e.ErrorMessage).First()).ToList()
                                    .Where(m => m.Value.Count() > 0);

                vm.Careers = _careerRepository.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                }).ToList();

                return Json(new
                {
                    status = 400,
                    errors = errorList
                });
            }


        }
    }
}