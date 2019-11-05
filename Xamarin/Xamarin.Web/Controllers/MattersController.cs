using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var vm = new MatterViewModel();
            vm.Careers = _careerRepository.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            }).ToList();

            return PartialView("_CreatePartial", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MatterViewModel vm)
        {
            //if (ModelState.IsValid)
            //{

            //}

            //vm.Careers = _careerRepository.GetAll().Select(x => new SelectListItem
            //{
            //    Text = x.Name,
            //    Value = x.Id.ToString(),
            //}).ToList();

            try
            {
                if (!ModelState.IsValid)
                {
                    string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                    throw new Exception("Please correct the following errors: " + Environment.NewLine + messages);
                }

                var matter = new Matter();
                matter.Name = vm.Name;
                matter.CarrerId = Convert.ToInt32(vm.CareerId);

                await _matterRepository.CreateAsync(matter);
                //return RedirectToAction(nameof(Index));
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return PartialView("CreatePartial", Json(new { Result = "ERROR", Message = ex.Message }));
            }
        }
    }
}