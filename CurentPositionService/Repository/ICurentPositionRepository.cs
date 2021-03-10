using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CurentPositionService.Models;

namespace CurentPositionService.Repository
{
    public interface ICurentPositionRepository: IRepository<CurentPosition>
    {
        Task<IEnumerable<CurentPosition>> GetCurentPositions();
        Task<CurentPosition> GetCurentPosition(int id);
        Task PutCurentPosition(int id, CurentPosition curentPosition);
        Task<CurentPosition> PostCurentPosition(CurentPosition curentPosition);
        Task DeleteCurentPosition(int id);
    }
}