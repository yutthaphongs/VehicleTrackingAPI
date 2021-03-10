using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurentPositionService.Models
{
    public class CurentPosition
    {
        [Key]
        public int CurentPositionId { get; set; }
        [Column(TypeName = "nvarchar(60)")]
        public string GpsSerialNumber { get; set; }
        [Column(TypeName = "decimal(9,6)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(9,6)")]
        public decimal Longitude { get; set; }
        [Column(TypeName = "decimal(12,4)")]
        public decimal Fuel { get; set; }
        [Column(TypeName = "decimal(12,4)")]
        public decimal Speed { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CurentDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "nvarchar(60)")]
        public string CreateBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdateDate { get; set; }
        [Column(TypeName = "nvarchar(60)")]
        public string UpdateBy { get; set; }
    }
}   