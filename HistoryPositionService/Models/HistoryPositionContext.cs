using System;
using Microsoft.EntityFrameworkCore;

namespace HistoryPositionService.Models
{
    public class HistoryPositionContext : DbContext
    {
        public HistoryPositionContext(DbContextOptions<HistoryPositionContext> options) : base(options)
        {
            
        }
        public DbSet<HistoryPosition> HistoryPositions { get; set; }
    }
}   