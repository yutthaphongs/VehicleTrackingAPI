using MediatR;
using GPSRecordService.Models;

namespace GPSRecordService.Service.Command
{
    public class CreateGPSRecordCommand : IRequest<GPSRecord>
    {
        public GPSRecord gpsRecord { get; set; }
    }
}