using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleService.Models;
using VehicleService.Repository;

namespace VehicleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        // GET: api/Vehicle
        //[HttpGet]
        // public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        // {
        //     return await _vehicleRepository.Vehicles.ToListAsync();
        // }

        // GET: api/Vehicle/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        // {
        //     var vehicle = await _vehicleRepository.Vehicles.FindAsync(id);

        //     if (vehicle == null)
        //     {
        //         return NotFound();
        //     }

        //     return vehicle;
        // }

        // PUT: api/Vehicle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        // public async Task<IActionResult> PutVehicle(int id, Vehicle vehicle)
        // {
        //     if (id != vehicle.VehicleId)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(vehicle).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!VehicleExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // POST: api/Vehicle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        // public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
        // {
        //     _context.Vehicles.Add(vehicle);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetVehicle", new { id = vehicle.VehicleId }, vehicle);
        // }

        // DELETE: api/Vehicle/5
        //[HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteVehicle(int id)
        // {
        //     var vehicle = await _context.Vehicles.FindAsync(id);
        //     if (vehicle == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Vehicles.Remove(vehicle);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // private bool VehicleExists(int id)
        // {
        //     return _context.Vehicles.Any(e => e.VehicleId == id);
        // }
    }
}
