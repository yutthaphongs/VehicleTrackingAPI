using System;
using Microsoft.EntityFrameworkCore;

namespace CurentPositionService.Models
{
    public class CurentPositionContext : DbContext
    {
        public CurentPositionContext(DbContextOptions<CurentPositionContext> options) : base(options)
        {
            
        }
        public DbSet<CurentPosition> CurentPositions { get; set; }
    }
}   