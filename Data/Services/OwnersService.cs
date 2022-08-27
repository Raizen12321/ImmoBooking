using ImmoBooking.Data.Base;
using ImmoBooking.Models;

namespace ImmoBooking.Data.Services
{
    public class OwnersService:EntityBaseRepository<Owner>,IOwnersService
    {
        public OwnersService(AppDbContext context) : base(context)
        {
            
        }
    }
}
