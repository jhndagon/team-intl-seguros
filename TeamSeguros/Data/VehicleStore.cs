using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSeguros.Models;

namespace TeamSeguros.Data
{

    public class VehicleStore
    {
        public SeguroContext SeguroContext { get; set; }

        public VehicleStore(SeguroContext seguroContext)
        {
            SeguroContext = seguroContext;
        }

        internal void AddVehicle(Vehicle vehicle)
        {
            SeguroContext.Vehicle.Add(vehicle);
            SeguroContext.SaveChanges();
        }

        internal List<Vehicle> GetVehicles(Guid id)
        {
            return SeguroContext.Vehicle.Where(x => x.ClientId == id).ToList();
        }

        internal Vehicle GetVehicleById(Guid id)
        {
            return SeguroContext.Vehicle.FirstOrDefault(x => x.Id == id);
        }

        internal void EditVehicle(Vehicle vehicle)
        {
            SeguroContext.Vehicle.Update(vehicle);
            SeguroContext.SaveChanges();
        }

        internal List<Vehicle> GetVehiclesByClientId(Guid id)
        {
            return SeguroContext.Vehicle.Where(x => x.ClientId == id).ToList();
        }

        internal void DeleteVehicle(Guid id)
        {
            var Vehicle = GetVehicleById(id);
            SeguroContext.Vehicle.Remove(Vehicle);
            SeguroContext.SaveChanges();
        }
    }
}
