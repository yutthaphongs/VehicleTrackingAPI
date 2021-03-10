
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HistoryPositionService.Models;

namespace HistoryPositionService.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly HistoryPositionContext _historyPositionContext;

        public Repository(HistoryPositionContext historyPositionContext)
        {
            _historyPositionContext = historyPositionContext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _historyPositionContext.Set<TEntity>();
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
                await _historyPositionContext.AddAsync(entity);
                await _historyPositionContext.SaveChangesAsync();

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
                _historyPositionContext.Update(entity);
                await _historyPositionContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated {ex.Message}");
            }
        }
    }
}