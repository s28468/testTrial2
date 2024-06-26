using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mockTest2.Helpers;
using mockTest2.Models;
using mockTest2.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace mockTest2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompetitionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CompetitionsController> _logger;

        public CompetitionsController(ApplicationDbContext context, ILogger<CompetitionsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("driver/{driverId}")]
        public async Task<ActionResult<IEnumerable<object>>> GetDriverCompetitions(int driverId)
        {
            try
            {
                var driver = await _context.Drivers.FindAsync(driverId);
                if (driver == null)
                {
                    return NotFound(new { Message = "Driver not found" });
                }

                var competitions = await _context.DriverCompetitions
                    .Where(dc => dc.DriverId == driverId)
                    .Include(dc => dc.Competition)
                    .ToListAsync();

                var result = competitions.Select(dc => new
                {
                    dc.Competition.Name,
                    dc.Date
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching driver competitions");
                return StatusCode(500, new { title = "Internal server error. Please retry later.", status = 500 });
            }
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignDriverToCompetition(AssignDriverToCompetitionDto dto)
        {
            try
            {
                var driver = await _context.Drivers.FindAsync(dto.DriverId);
                if (driver == null)
                {
                    return NotFound(new { Message = "Driver not found" });
                }

                var competition = await _context.Competitions.FindAsync(dto.CompetitionId);
                if (competition == null)
                {
                    return NotFound(new { Message = "Competition not found" });
                }

                var driverCompetition = new DriverCompetition
                {
                    DriverId = dto.DriverId,
                    CompetitionId = dto.CompetitionId,
                    Date = dto.Date 
                };

                _context.DriverCompetitions.Add(driverCompetition);
                await _context.SaveChangesAsync();

                return Ok(driverCompetition);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while assigning driver to competition");
                return StatusCode(500, new { title = "Internal server error. Please retry later.", status = 500 });
            }
        }
    }
}
