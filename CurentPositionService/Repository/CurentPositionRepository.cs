using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CurentPositionService.Models;
using System.Collections.Generic;

namespace CurentPositionService.Repository
{
    public class CurentPositionRepository : Repository<CurentPosition>, ICurentPositionRepository
    {
        public CurentPositionRepository(CurentPositionContext vehicleContext) : base(vehicleContext)
        {
        }

        public async Task<IEnumerable<CurentPosition>> GetCurentPositions()
        {
             return await _curentPositionContext.CurentPositions.ToListAsync();
        }
        public async Task<CurentPosition> GetCurentPosition(int id)
        {
            var curentPosition = await _curentPositionContext.CurentPositions.FindAsync(id);
          
            return curentPosition;
        }
        public async Task PutCurentPosition(int id, CurentPosition curentPosition)
        {             
            _curentPositionContext.Entry(curentPosition).State = EntityState.Modified;
        
            await _curentPositionContext.SaveChangesAsync();              
        }
        public async Task<CurentPosition> PostCurentPosition(CurentPosition curentPosition)
        {
            _curentPositionContext.CurentPositions.Add(curentPosition);
            await _curentPositionContext.SaveChangesAsync();

            return curentPosition;

        }
        public async Task DeleteCurentPosition(int id)
        {
            var curentPosition = await _curentPositionContext.CurentPositions.FindAsync(id);
            if (curentPosition != null)
            {
                _curentPositionContext.CurentPositions.Remove(curentPosition);
                await _curentPositionContext.SaveChangesAsync();
            }
        }

    }
}