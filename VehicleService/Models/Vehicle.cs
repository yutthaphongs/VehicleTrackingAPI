using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleService.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string VehicleName { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string NumberPlate { get; set; }
        [Column(TypeName = "nvarchar(60)")]
        public string OwnerName { get; set; }
        [Column(TypeName = "nvarchar(60)")]
        public string GpsSerialNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdateDate { get; set; }
        [Column(TypeName = "nvarchar(60)")]
        public string CreateBy { get; set; }
        [Column(TypeName = "nvarchar(60)")]
        public string UpdateBy { get; set; }
        [Column(TypeName = "bit")]
        public bool Active { get; set; } = true;
    }
}   