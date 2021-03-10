using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CurentPositionService.Models;
using CurentPositionService.Repository;

namespace CurentPositionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurentPositionController : ControllerBase
    {
        private readonly ICurentPositionRepository _curentPositionRepository;

        public CurentPositionController(ICurentPositionRepository curentPositionRepository)
        {
            _curentPositionRepository = curentPositionRepository;
        }

        // GET: api/CurentPosition
        [HttpGet]
        public async Task<IEnumerable<CurentPosition>> GetCurentPositions()
        {
            return await _curentPositionRepository.GetCurentPositions();
        }

        // GET: api/CurentPosition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CurentPosition>> GetCurentPosition(int id)
        {
            var curentPosition = await _curentPositionRepository.GetCurentPosition(id);

            if (curentPosition == null)
            {
                return NotFound();
            }

            return curentPosition;
        }

        // PUT: api/CurentPosition/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurentPosition(int id, CurentPosition curentPosition)
        {
            if (id != curentPosition.CurentPositionId)
            {
                return BadRequest();
            }

            try
            {
                await _curentPositionRepository.PutCurentPosition(id,curentPosition);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/CurentPosition
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CurentPosition>> PostCurentPosition(CurentPosition curentPosition)
        {
            await _curentPositionRepository.PostCurentPosition(curentPosition);

            return CreatedAtAction("GetCurentPosition", new { id = curentPosition.CurentPositionId }, curentPosition);
        }

        // DELETE: api/CurentPosition/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurentPosition(int id)
        {
            await _curentPositionRepository.DeleteCurentPosition(id);
            return Ok();
        }

    }
}
