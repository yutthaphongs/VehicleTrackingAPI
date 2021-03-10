using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GPSRecordService.Models;
using GPSRecordService.Repository;
using Microsoft.Extensions.Logging;
using EventBus.Abstractions;
using GPSRecordService.IntegrationEvents;

namespace GPSRecordService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GPSRecordController : ControllerBase
    {
        private readonly IGPSRecordRepository _gpsRecordRepository;
        //private readonly IEventBus _eventBus;
        //private readonly ILogger<GPSRecordController> _logger;


        public GPSRecordController(
            IGPSRecordRepository gpsRecordRepository
            //, 
            //IEventBus eventBus, 
            //ILogger<GPSRecordController> logger
            )
        { 
            _gpsRecordRepository = gpsRecordRepository;
            //_eventBus = eventBus;
            //_logger = logger;
        }

        // POST: api/GPSRecord
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GPSRecord>> PostGPSRecord(GPSRecord gPSRecord)
        {
            var result = await _gpsRecordRepository.PostGPSRecord(gPSRecord);

            //Publish to RabbitMQ
            // var eventMessage = new GPSRecordIntegrationEvent(Guid.NewGuid(),
            //     gPSRecord.GPSRecordId,
            //     gPSRecord.GpsSerialNumber,
            //     gPSRecord.Latitude,
            //     gPSRecord.Longitude,
            //     gPSRecord.Fuel,
            //     gPSRecord.Speed,
            //     gPSRecord.CreateDate,
            //     gPSRecord.CreateBy
            //     );


            // try
            // {
            //     _eventBus.Publish(eventMessage);
            // }
            // catch (Exception ex)
            // {
            //     _logger.LogError(ex, "ERROR Publishing integration event: {IntegrationEventId} from {AppName}", eventMessage.GPSRecordId,"GPSRecordController");
            //     throw;
            // }

            return CreatedAtAction("GetGPSRecord", new { id = gPSRecord.GPSRecordId }, gPSRecord);
        }
    }
}
