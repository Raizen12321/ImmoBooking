using ImmoBooking.Data;
using ImmoBooking.Data.Services;
using ImmoBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ImmoBooking.Controllers
{
    public class OwnersController : Controller
    {
        private readonly IOwnersService _service;

        public OwnersController(IOwnersService service)
        {
            _service= service;
        }
        public async Task<IActionResult> Index()
        {
            var allOwners = await _service.GetAllAsync();
            return View(allOwners);
        }

        public async Task<IActionResult> Details(int id)
        {
            var ownerDetatils = await _service.GetByIdAsync(id);
            if (ownerDetatils == null) return View("NotFound");
            return View(ownerDetatils);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL")] Owner owner)
        {
            if (!ModelState.IsValid)
            {
                return View(owner);
            }
            await _service.AddAsync(owner);
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Delete(int id)
        {
            var ownerDetails = await _service.GetByIdAsync(id);

            if (ownerDetails == null) return View("NotFound");
            return View(ownerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ownerDetails = await _service.GetByIdAsync(id);
            if (ownerDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }



        //Get : Owners/Edit/(id)
        public async Task<IActionResult> Edit(int id)
        {
            var ownerDetails = await _service.GetByIdAsync(id);

            if (ownerDetails == null) return View("NotFound");
            return View(ownerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL")] Owner owner)
        {
            if (!ModelState.IsValid)
            {
                return View(owner);
            }
            await _service.UpdateAsync(id, owner);
            return RedirectToAction(nameof(Index));
        }

    }
}
