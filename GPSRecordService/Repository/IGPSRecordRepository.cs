using System;
using System.Threading;
using System.Threading.Tasks;
using GPSRecordService.Models;

namespace GPSRecordService.Repository
{
    public interface IGPSRecordRepository: IRepository<GPSRecord>
    {
        Task<GPSRecord> GetGPSRecordByIdAsync(int id);
        Task<GPSRecord> PostGPSRecord(GPSRecord gPSRecord);
    }
}