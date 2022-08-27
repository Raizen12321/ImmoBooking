using ImmoBooking.Data.Base;
using ImmoBooking.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImmoBooking.Data.Services
{
    public class AgentsService : EntityBaseRepository<Agent>, IAgentsService
    {
        public AgentsService(AppDbContext context) : base(context) { }
    }
}
