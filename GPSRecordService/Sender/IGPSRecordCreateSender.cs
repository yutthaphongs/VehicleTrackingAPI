using System;
using GPSRecordService.Models;

namespace GPSRecordService.Sender
{
    public interface IGPSRecordCreateSender
    {
        void SendGPSRecord(GPSRecord gpsRecord);
    }
}