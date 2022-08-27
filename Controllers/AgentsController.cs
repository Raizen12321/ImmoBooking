using ImmoBooking.Data;
using ImmoBooking.Data.Services;
using ImmoBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ImmoBooking.Controllers
{
    public class AgentsController : Controller
    {
        private readonly IAgentsService _service;

        public AgentsController(IAgentsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allAgents = await _service.GetAllAsync();
            return View(allAgents);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Email,Contact")]Agent agent)
        {
            if (!ModelState.IsValid)
            {
                return View(agent);
            }
            await _service.AddAsync(agent);
            return RedirectToAction(nameof(Index));
        }

        //Get : Agents/Details/(id)
        public async Task<IActionResult> Details(int id)
        {
            var agentDetails = await _service.GetByIdAsync(id);

            if(agentDetails == null) return View("NotFound");
            return View(agentDetails);
        }

        //Get : Agents/Edit/(id)
        public async Task<IActionResult> Edit(int id)
        {
            var agentDetails = await _service.GetByIdAsync(id);

            if (agentDetails == null) return View("NotFound");
            return View(agentDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Email,Contact")] Agent agent)
        {
            if (!ModelState.IsValid)
            {
                return View(agent);
            }
            await _service.UpdateAsync(id,agent);
            return RedirectToAction(nameof(Index));
        }

        //Get : Agents/Delete/(id)
        public async Task<IActionResult> Delete(int id)
        {
            var agentDetails = await _service.GetByIdAsync(id);

            if (agentDetails == null) return View("NotFound");
            return View(agentDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agentDetails = await _service.GetByIdAsync(id);
            if (agentDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
