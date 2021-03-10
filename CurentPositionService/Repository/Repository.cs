
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CurentPositionService.Models;

namespace CurentPositionService.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly CurentPositionContext _curentPositionContext;

        public Repository(CurentPositionContext curentPositionContext)
        {
            _curentPositionContext = curentPositionContext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _curentPositionContext.Set<TEntity>();
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
                await _curentPositionContext.AddAsync(entity);
                await _curentPositionContext.SaveChangesAsync();

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
                _curentPositionContext.Update(entity);
                await _curentPositionContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated {ex.Message}");
            }
        }
    }
}