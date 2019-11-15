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
    public class IndexModel : PageModel
    {
        public VehicleStore VehicleStore { get; set; }
        public ClientStore ClientStore { get; set; }
        public Client Client { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public IndexModel(VehicleStore vehicleStore, ClientStore clientStore)
        {
            VehicleStore = vehicleStore;
            ClientStore = clientStore;
        }
        public IActionResult OnPostDelete(Guid id)
        {
            var idCliente = VehicleStore.GetVehicleById(id).ClientId;
            VehicleStore.DeleteVehicle(id);
            return RedirectToPage("./Index", new { id = idCliente});
        }
        public void OnGet(Guid id)
        {
            Client = ClientStore.GetClientById(id);
            Vehicles = Client.Vehiculos;
        }

    }
}