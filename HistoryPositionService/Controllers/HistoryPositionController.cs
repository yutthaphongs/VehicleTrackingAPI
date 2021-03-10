using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HistoryPositionService.Models;
using HistoryPositionService.Repository;

namespace HistoryPositionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryPositionController : ControllerBase
    {
        private readonly IHistoryPositionRepository _historyPositionRepository;
        //private readonly IEventBus _eventBus;
        //private readonly ILogger<GPSRecordController> _logger;

        public HistoryPositionController(IHistoryPositionRepository historyPositionRepository)
        {
            _historyPositionRepository = historyPositionRepository;
        }

        // GET: api/HistoryPosition
        [HttpGet]
        public async Task<IEnumerable<HistoryPosition>> GetHistoryPositions()
        {
            var result = await _historyPositionRepository.GetHistoryPositions();
            return result;
        }

        // GET: api/HistoryPosition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoryPosition>> GetHistoryPosition(int id)
        {
            var historyPosition = await _historyPositionRepository.GetHistoryPosition(id);

            if (historyPosition == null)
            {
                return NotFound();
            }

            return historyPosition;
        }

        // GET: api/HistoryPosition
        [HttpGet]
        public async Task<IEnumerable<HistoryPosition>> GetPositionDuringTime(DateTime startDate,DateTime endDate)
        {
            var result = await _historyPositionRepository.GetPositionDuringTime(startDate,endDate);
            return result;
        }
        // POST: api/HistoryPosition
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistoryPosition>> PostHistoryPosition(HistoryPosition historyPosition)
        {
            var result = await _historyPositionRepository.PostHistoryPosition(historyPosition);
            return CreatedAtAction("GetHistoryPosition", new { id = historyPosition.HistoryPositionId }, historyPosition);
        }

    }
}
