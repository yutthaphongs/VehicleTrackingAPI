using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VehicleService.Models;

namespace VehicleService.Repository
{
    public interface IVehicleRepository: IRepository<Vehicle>
    {
        Task<IEnumerable<Vehicle>> GetVehicles();
        //Task<Vehicle> GetVehicle(int id);
        //Task PutVehicle(int id, Vehicle vehicle);
        //Task DeleteVehicle(int id);
    }
}