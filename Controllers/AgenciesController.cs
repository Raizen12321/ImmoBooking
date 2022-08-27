using ImmoBooking.Data;
using ImmoBooking.Data.Services;
using ImmoBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ImmoBooking.Controllers
{
    public class AgenciesController : Controller
    {
        private readonly IAgenciesService _service;

        public AgenciesController(IAgenciesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,LogoURL,Email,Description")] Agencie agencie)
        {
            if (!ModelState.IsValid)
            {
                return View(agencie);
            }
            await _service.AddAsync(agencie);
            return RedirectToAction(nameof(Index));
        }

        //Get : Agencies/Details/(id)
        public async Task<IActionResult> Details(int id)
        {
            var agenciesDetails = await _service.GetByIdAsync(id);

            if (agenciesDetails == null) return View("NotFound");
            return View(agenciesDetails);
        }

        //Get : Agencies/Edit/(id)
        public async Task<IActionResult> Edit(int id)
        {
            var agenciesDetails = await _service.GetByIdAsync(id);

            if (agenciesDetails == null) return View("NotFound");
            return View(agenciesDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LogoURL,Email,Description")] Agencie agencie)
        {
            if (!ModelState.IsValid)
            {
                return View(agencie);
            }
            await _service.UpdateAsync(id, agencie);
            return RedirectToAction(nameof(Index));
        }

        //Get : Agencies/Delete/(id)
        public async Task<IActionResult> Delete(int id)
        {
            var agencieDetails = await _service.GetByIdAsync(id);

            if (agencieDetails == null) return View("NotFound");
            return View(agencieDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agencieDetails = await _service.GetByIdAsync(id);
            if (agencieDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
