using System;
using Microsoft.EntityFrameworkCore;

namespace GPSRecordService.Models
{
    public class GPSRecordContext : DbContext
    {
        public GPSRecordContext(DbContextOptions<GPSRecordContext> options) : base(options)
        {
            
        }
        public DbSet<GPSRecord> GPSRecords { get; set; }
    }
}   