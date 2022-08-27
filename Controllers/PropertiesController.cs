using ImmoBooking.Data;
using ImmoBooking.Data.Services;
using ImmoBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ImmoBooking.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly IPropertiesService _service;

        public PropertiesController(IPropertiesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allProperties = await _service.GetAllAsync(n => n.Agencie);
            return View(allProperties);
        }
        public async Task<IActionResult> Filter(string searchString)
        {
            var allProperties = await _service.GetAllAsync(n => n.Agencie);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allProperties.Where(n=>n.Name.ToLower().Contains(searchString.ToLower())|| n.Description.ToLower()
                .Contains(searchString.ToLower())).ToList();
                return View("Index",filteredResult);
            }

            return View("Index", allProperties);
        }
        public IActionResult Images()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var propertyDetails = await _service.GetPropertyByIdAsync(id);
            return View(propertyDetails);
        }

        //GET : Properties/Create

        public async Task<IActionResult> Create()
        {
            var propertyDropdownData = await _service.GetNewPropertyDropdownsValues();

            ViewBag.Agencies = new SelectList(propertyDropdownData.Agencies, "Id", "Name");
            ViewBag.Owners = new SelectList(propertyDropdownData.Owners, "Id", "FullName");
            ViewBag.Agents = new SelectList(propertyDropdownData.Agents, "Id", "FullName");

            return View();
        }
        
        [HttpPost]

        public async Task<IActionResult> Create(NewPropertyVM property)
        {
            if (!ModelState.IsValid)
            {
                var propertyDropdownData = await _service.GetNewPropertyDropdownsValues();

                ViewBag.Agencies = new SelectList(propertyDropdownData.Agencies, "Id", "Name");
                ViewBag.Owners = new SelectList(propertyDropdownData.Owners, "Id", "FullName");
                ViewBag.Agents = new SelectList(propertyDropdownData.Agents, "Id", "FullName");

                return View(property);
            }
            await _service.AddNewPropertyAsync(property);
            return RedirectToAction(nameof(Index));
        }


        //GET : Properties/Edit

        public async Task<IActionResult> Edit(int id)
        {
            var propertyDetails = await _service.GetPropertyByIdAsync(id);
            if(propertyDetails == null) return View("NotFound");

            var response = new NewPropertyVM()
            {
                Id = propertyDetails.Id,
                Name = propertyDetails.Name,
                Description = propertyDetails.Description,
                Price = propertyDetails.Price,
                AvailableStart = propertyDetails.AvailableStart,
                AvailableEnd = propertyDetails.AvailableEnd,
                MainImageURL = propertyDetails.MainImageURL,
                PropertyCategorie = propertyDetails.PropertyCategorie,
                AgencieId = propertyDetails.AgencieId,
                OwnerId = propertyDetails.OwnerId,
                AgentIds = propertyDetails.Properties_Agents.Select(n => n.AgentId).ToList(),
            };
            
            var propertyDropdownData = await _service.GetNewPropertyDropdownsValues();

            ViewBag.Agencies = new SelectList(propertyDropdownData.Agencies, "Id", "Name");
            ViewBag.Owners = new SelectList(propertyDropdownData.Owners, "Id", "FullName");
            ViewBag.Agents = new SelectList(propertyDropdownData.Agents, "Id", "FullName");

            return View(response);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id,NewPropertyVM property)
        {
            if(id!= property.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var propertyDropdownData = await _service.GetNewPropertyDropdownsValues();

                ViewBag.Agencies = new SelectList(propertyDropdownData.Agencies, "Id", "Name");
                ViewBag.Owners = new SelectList(propertyDropdownData.Owners, "Id", "FullName");
                ViewBag.Agents = new SelectList(propertyDropdownData.Agents, "Id", "FullName");

                return View(property);
            }
            await _service.UpdatePropertyAsync(property);
            return RedirectToAction(nameof(Index));
        }
    }
}
