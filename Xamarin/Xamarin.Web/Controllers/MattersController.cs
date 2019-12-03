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

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MatterViewModel matterviewmodel)
        {
            if (ModelState.IsValid)
            {
                var matter = new Matter
                {
                    Name = matterviewmodel.Name,
                    CarrerId = Convert.ToInt32(matterviewmodel.CareerId)
                };
                await _matterRepository.CreateAsync(matter);
                return RedirectToAction(nameof(Index));
            }

            matterviewmodel.Careers = _careerRepository.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            }).ToList();

            return View(matterviewmodel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matter = await _matterRepository.GetByIdAsync(id.Value);
            if (matter == null)
            {
                return NotFound();
            }

            var vm = new MatterViewModel()
            {
                Id = matter.Id,
                Name = matter.Name,
                CareerId = Convert.ToString(matter.CarrerId),
                Careers = _careerRepository.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                }).ToList()
            };

            return View(vm);
        }
    }
}