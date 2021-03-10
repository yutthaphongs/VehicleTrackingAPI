using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HistoryPositionService.Models;

namespace HistoryPositionService.Repository
{
    public interface IHistoryPositionRepository: IRepository<HistoryPosition>
    {
        Task<IEnumerable<HistoryPosition>> GetHistoryPositions();
        Task<HistoryPosition> GetHistoryPosition(int id);
        Task<IEnumerable<HistoryPosition>> GetPositionDuringTime(DateTime startDate,DateTime endDate);
        Task<HistoryPosition> PostHistoryPosition(HistoryPosition historyPosition);
    }
}