using ImmoBooking.Data.Base;
using ImmoBooking.Data.ViewModels;
using ImmoBooking.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImmoBooking.Data.Services
{
    public interface IPropertiesService : IEntityBaseRepository<Property>
    {
        Task<Property> GetPropertyByIdAsync(int id);

        Task<NewPropertyDropdownsVM> GetNewPropertyDropdownsValues();

        Task AddNewPropertyAsync(NewPropertyVM data);

        Task UpdatePropertyAsync(NewPropertyVM data);

    }
}
