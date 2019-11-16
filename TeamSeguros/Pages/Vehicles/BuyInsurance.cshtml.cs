using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeamSeguros.Data;

namespace TeamSeguros.Pages.Vehicles
{
    public class BuyInsuranceModel : PageModel
    {
        public VehicleStore VehicleStore { get; set; }
        public ClientStore ClientStore { get; set; }
        [BindProperty]
        public Guid Id { get; set; }
        [TempData]
        public String Message { get; set; }
        public BuyInsuranceModel(VehicleStore vehicleStore, ClientStore clientStore)
        {
            VehicleStore = vehicleStore;
            ClientStore = clientStore;
        }
        public IActionResult OnGet(Guid id)
        {
            var vehicle = VehicleStore.GetVehicleById(id);
            var client = ClientStore.GetClientById(vehicle.ClientId);
            Id = vehicle.ClientId;
            double precioBase = 1000000.0;
            if(DateTime.Now.Year - client.FechaNacimiento.Year < 16)
            {
                Message = "No se puede vender seguros a clientes menores de 16 años.";
                return Page();
            }
            if(client.CiudadResidencia.CompareTo("Medellin") == 0)
            {
                precioBase += 100000;
            }
            var age = Services.CalculateAge.Calcule(client.FechaNacimiento);
            if(age >= 16 && age < 25)
            {
                precioBase += 300000;
            }
            else if(age >=25 && age <= 40)
            {
                precioBase += 100000;
            }
            if(DateTime.Now.Year - vehicle.Anio > 10)
            {
                precioBase += 50000;
            }
            vehicle.ValorSeguro = precioBase;
            VehicleStore.EditVehicle(vehicle);
            Message = "El valor final del seguro es de " + precioBase;
            return RedirectToPage("./Index", new { id = client.Id });
        }
    }
}