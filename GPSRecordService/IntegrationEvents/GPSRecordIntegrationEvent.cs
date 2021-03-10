using EventBus.Events;
using System;

namespace GPSRecordService.IntegrationEvents
{
    public class GPSRecordIntegrationEvent : IntegrationEvent
    {
        public Guid RequestId { get; set; }
        public int GPSRecordId { get; set; }
        public string GpsSerialNumber { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal Fuel { get; set; }
        public decimal Speed { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }

        public GPSRecordIntegrationEvent(Guid requestId,int gpsRecordId,string gpsSerialNumber,
        decimal latitude,decimal longitude,decimal fuel,decimal speed,DateTime createDate,string createBy)
        {
            RequestId = requestId;
            GPSRecordId = gpsRecordId;
            GpsSerialNumber = gpsSerialNumber;
            Latitude = latitude;
            Longitude = longitude;
            Fuel = fuel;
            Speed = speed;
            CreateDate = createDate;
            CreateBy = createBy;
        }

    }
}
