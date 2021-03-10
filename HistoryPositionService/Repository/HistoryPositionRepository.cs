using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HistoryPositionService.Models;
using System.Collections.Generic;

namespace HistoryPositionService.Repository
{
    public class HistoryPositionRepository : Repository<HistoryPosition>, IHistoryPositionRepository
    {
        public HistoryPositionRepository(HistoryPositionContext historyPositionContext) : base(historyPositionContext)
        {
        }

        public async Task<IEnumerable<HistoryPosition>> GetHistoryPositions()
        {
            return await _historyPositionContext.HistoryPositions.ToListAsync();
        }
        public async Task<HistoryPosition> GetHistoryPosition(int id)
        {
            var historyPosition = await _historyPositionContext.HistoryPositions.FindAsync(id);

            return historyPosition;
        }
        public async Task<IEnumerable<HistoryPosition>> GetPositionDuringTime(DateTime startDate,DateTime endDate)
        {
            var historyPositionDuringTime = await _historyPositionContext.HistoryPositions.Include(e => e.CreateDate.CompareTo(startDate) >= 0 && e.CreateDate.CompareTo(endDate) <= 0).ToListAsync();

            return historyPositionDuringTime;
        }
        public async Task<HistoryPosition> PostHistoryPosition(HistoryPosition historyPosition)
        {
            _historyPositionContext.HistoryPositions.Add(historyPosition);
            await _historyPositionContext.SaveChangesAsync();
            
            return historyPosition;
        }

    }
}