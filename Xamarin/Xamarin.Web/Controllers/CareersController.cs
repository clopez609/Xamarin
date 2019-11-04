using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xamarin.Web.Data;
using Xamarin.Web.Data.Entities;
using Xamarin.Web.Helpers;
using Xamarin.Web.Models;

namespace Xamarin.Web.Controllers
{
    [Authorize]
    public class CareersController : Controller
    {
        private readonly ICareerRepository _careerRepository;
        private readonly IUserHelper _userHelper;

        public CareersController(
            ICareerRepository careerRepository,
            IUserHelper userHelper)
        {
            _careerRepository = careerRepository;
            _userHelper = userHelper;
        }

        public IActionResult Index()
        {
            return View(_careerRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Career career)
        {
            if (ModelState.IsValid)
            {
                await _careerRepository.CreateAsync(career);
                return RedirectToAction(nameof(Index));
            }
            return View(career);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var career = await _careerRepository.GetByIdAsync(id.Value);
            if (career == null)
            {
                return NotFound();
            }

            var viewModel = new CareerViewModel();
            viewModel.Id = career.Id;
            viewModel.Name = career.Name;
            return PartialView("EditPartial", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CareerViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var career = new Career();
                career.Id = vm.Id;
                career.Name = vm.Name;
                try
                {
                    await _careerRepository.UpdateAsync(career);
                }
                catch
                {
                    if (!await _careerRepository.ExistAsync(career.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return PartialView("EditPartial", vm);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var career = await _careerRepository.GetByIdAsync(id.Value);
            if (career == null)
            {
                return NotFound();
            }

            return PartialView("DeletePartial", career);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var career = await _careerRepository.GetByIdAsync(id);
            await _careerRepository.DeleteAsync(career);
            return RedirectToAction(nameof(Index));
        }
    }
}