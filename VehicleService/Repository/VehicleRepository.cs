using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleService.Models;
using System.Collections.Generic;

namespace VehicleService.Repository
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(VehicleContext vehicleContext) : base(vehicleContext)
        {
        }

        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            return await _vehicleContextContext.Vehicles.ToListAsync();
        }
        public async Task<Vehicle> GetVehicle(int id)
        {
            var vehicle = await _vehicleContextContext.Vehicles.FindAsync(id);

            return vehicle;
        }
        public async Task PutVehicle(int id, Vehicle vehicle)
        {
             var result = _vehicleContextContext.Entry(vehicle).State = EntityState.Modified;
             await _vehicleContextContext.SaveChangesAsync();       
        }
        public async Task<Vehicle> PostHistoryPosition(Vehicle vehicle)
        {
            _vehicleContextContext.Vehicles.Add(vehicle);
            await _vehicleContextContext.SaveChangesAsync();
            
            return vehicle;
        }

    }
}