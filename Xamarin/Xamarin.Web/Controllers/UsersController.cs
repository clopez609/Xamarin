using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xamarin.Web.Data;
using Xamarin.Web.Data.Entities;

namespace Xamarin.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IRepository _repository;
        public UsersController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: Users
        public IActionResult Index()
        {
            return View(_repository.GetUsers());
        }

        // GET: Users/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _repository.GetUser(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                _repository.AddUser(user);
                await _repository.SaveAllAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _repository.GetUser(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.UpdateUser(user);
                    await _repository.SaveAllAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_repository.UserExists(user.Id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _repository.GetUser(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = _repository.GetUser(id);
            _repository.RemoveUser(user);
            await _repository.SaveAllAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
