
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleService.Models;

namespace VehicleService.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly VehicleContext _vehicleContextContext;

        public Repository(VehicleContext vehicleContextContext)
        {
            _vehicleContextContext = vehicleContextContext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _vehicleContextContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _vehicleContextContext.AddAsync(entity);
                await _vehicleContextContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _vehicleContextContext.Update(entity);
                await _vehicleContextContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated {ex.Message}");
            }
        }
    }
}