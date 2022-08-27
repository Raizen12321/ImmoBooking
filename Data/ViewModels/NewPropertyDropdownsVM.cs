using ImmoBooking.Models;
using System.Collections.Generic;

namespace ImmoBooking.Data.ViewModels
{
    public class NewPropertyDropdownsVM
    {
        public NewPropertyDropdownsVM()
        {
            Owners = new List<Owner>();
            Agencies = new List<Agencie>();
            Agents = new List<Agent>();
        }

        public List<Owner> Owners { get; set; }

        public List<Agencie> Agencies { get; set; }

        public List<Agent> Agents { get; set; }
    }
}
