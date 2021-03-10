using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GPSRecordService.Models;

namespace GPSRecordService.Repository
{
    public class GPSRecordRepository : Repository<GPSRecord>, IGPSRecordRepository
    {
        public GPSRecordRepository(GPSRecordContext gpsRecordContext) : base(gpsRecordContext)
        {
        }

        public async Task<GPSRecord> GetGPSRecordByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _gpsRecordContext.GPSRecords.FirstOrDefaultAsync(x => x.GPSRecordId == id);
        }
        public async Task<GPSRecord> PostGPSRecord(GPSRecord gPSRecord)
        {
            _gpsRecordContext.GPSRecords.Add(gPSRecord);
            await _gpsRecordContext.SaveChangesAsync();
            
            return gPSRecord;
        }

    }
}