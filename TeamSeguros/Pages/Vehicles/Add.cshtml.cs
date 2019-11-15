using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeamSeguros.Data;
using TeamSeguros.Models;

namespace TeamSeguros.Pages.Vehicles
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public Guid IdClient { get; set; }
        public VehicleStore VehicleStore { get; set; }
        [BindProperty]
        public Vehicle Vehicle { get; set; }
        public AddModel(VehicleStore vehicleStore)
        {
            VehicleStore = vehicleStore;
        }
        public void OnGet(Guid id)
        {
            IdClient = id;
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Vehicle.ClientId = IdClient;
            VehicleStore.AddVehicle(Vehicle);
            return RedirectToPage("./Index", new { id = IdClient });
        }
    }
}