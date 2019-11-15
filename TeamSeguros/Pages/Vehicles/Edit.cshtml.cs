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
    public class EditModel : PageModel
    {
        public VehicleStore VehicleStore { get; set; }
        [BindProperty]
        public Vehicle Vehicle { get; set; }
        public EditModel(VehicleStore vehicleStore)
        {
            VehicleStore = vehicleStore;
        }
        public void OnGet(Guid id)
        {
            Vehicle = VehicleStore.GetVehicleById(id);
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            VehicleStore.EditVehicle(Vehicle);
            return RedirectToPage("./Index", new {id = Vehicle.ClientId });
        }
    }
}