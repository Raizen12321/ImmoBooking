using ImmoBooking.Data.Base;
using ImmoBooking.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImmoBooking.Data.Services
{
    public class AgenciesService : EntityBaseRepository<Agencie>, IAgenciesService
    {
        public AgenciesService(AppDbContext context) : base(context) { }
    }
}
