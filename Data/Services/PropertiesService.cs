using ImmoBooking.Data.Base;
using ImmoBooking.Data.ViewModels;
using ImmoBooking.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmoBooking.Data.Services
{
    public class PropertiesService : EntityBaseRepository<Property>, IPropertiesService
    {
        private readonly AppDbContext _context;
        public PropertiesService(AppDbContext context) : base(context) { _context = context; }

        public async Task<Property> GetPropertyByIdAsync(int id)
        {
            var propertyDetails = await _context.Properties
                .Include(a => a.Agencie)
                .Include(o => o.Owner)
                .Include(pa => pa.Properties_Agents).ThenInclude(a=> a.Agent)
                .FirstOrDefaultAsync(n=> n.Id == id);

            return propertyDetails;
        }


        public async Task<NewPropertyDropdownsVM> GetNewPropertyDropdownsValues()
        {
            var response = new NewPropertyDropdownsVM()
            {
                Agents = await _context.Agents.OrderBy(n => n.FullName).ToListAsync(),
                Agencies = await _context.Agencies.OrderBy(n => n.Name).ToListAsync(),
                Owners = await _context.Owners.OrderBy(n => n.FullName).ToListAsync()
            };
            

            return response;
        }

        public async Task AddNewPropertyAsync(NewPropertyVM data)
        {
            var newProperty = new Property()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                MainImageURL = data.MainImageURL,
                AgencieId = data.AgencieId,
                AvailableStart = data.AvailableStart,
                AvailableEnd = data.AvailableEnd,
                PropertyCategorie = data.PropertyCategorie,
                OwnerId = data.OwnerId

            };
            await _context.Properties.AddAsync(newProperty);
            await _context.SaveChangesAsync();

            // Add Property Agents

            foreach (var agentId in data.AgentIds)
            {
                var newAgentProperty = new Property_Agent()
                {
                    PropertyId = newProperty.Id,
                    AgentId = agentId,
                };
                await _context.Properties_Agents.AddAsync(newAgentProperty);
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePropertyAsync(NewPropertyVM data)
        {
            var dbProperty = await _context.Properties.FirstOrDefaultAsync(n=>n.Id == data.Id);

            if (dbProperty != null)
            {

                dbProperty.Name = data.Name;
                dbProperty.Description = data.Description;
                dbProperty.Price = data.Price;
                dbProperty.MainImageURL = data.MainImageURL;
                dbProperty.AgencieId = data.AgencieId;
                dbProperty.AvailableStart = data.AvailableStart;
                dbProperty.AvailableEnd = data.AvailableEnd;
                dbProperty.PropertyCategorie = data.PropertyCategorie;
                dbProperty.OwnerId = data.OwnerId;
                await _context.SaveChangesAsync();
            }

            //Remove Existing Actors

            var existingAgentsDb = _context.Properties_Agents.Where(n=>n.PropertyId == data.Id).ToList();
            _context.Properties_Agents.RemoveRange(existingAgentsDb);
            await _context.SaveChangesAsync();

            // Add Property Agents

            foreach (var agentId in data.AgentIds)
            {
                var newAgentProperty = new Property_Agent()
                {
                    PropertyId = data.Id,
                    AgentId = agentId,
                };
                await _context.Properties_Agents.AddAsync(newAgentProperty);
            }
            await _context.SaveChangesAsync();
        }
    }
}
