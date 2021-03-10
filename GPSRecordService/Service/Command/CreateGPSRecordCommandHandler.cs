using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GPSRecordService.Models;
using GPSRecordService.Repository;

namespace GPSRecordService.Service.Command
{
    public class CreateGPSRecordCommandHandler : IRequestHandler<CreateGPSRecordCommand, GPSRecord>
    {
        private readonly IGPSRecordRepository _gpsRecordRepository;

        public CreateGPSRecordCommandHandler(IGPSRecordRepository gpsRecordRepository)
        {
            _gpsRecordRepository = gpsRecordRepository;
        }

        public async Task<GPSRecord> Handle(CreateGPSRecordCommand request, CancellationToken cancellationToken)
        {
            return await _gpsRecordRepository.AddAsync(request.gpsRecord);
        }
    }
}