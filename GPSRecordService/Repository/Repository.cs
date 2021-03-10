using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GPSRecordService.Models;

namespace GPSRecordService.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly GPSRecordContext _gpsRecordContext;

        public Repository(GPSRecordContext gpsRecordContext)
        {
            _gpsRecordContext = gpsRecordContext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _gpsRecordContext.Set<TEntity>();
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
                await _gpsRecordContext.AddAsync(entity);
                await _gpsRecordContext.SaveChangesAsync();

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
                _gpsRecordContext.Update(entity);
                await _gpsRecordContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated {ex.Message}");
            }
        }
    }
}