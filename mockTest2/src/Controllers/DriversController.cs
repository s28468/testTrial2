using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mockTest2.Helpers;
using mockTest2.Models;
using mockTest2.DTO;

namespace mockTest2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriversController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DriversController> _logger;

        public DriversController(ApplicationDbContext context, ILogger<DriversController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverDto>>> GetDrivers([FromQuery] string sortBy = "FirstName", CancellationToken cancellationToken = default)
        {
            var drivers = await _context.Drivers
                .Include(d => d.Car)
                .ThenInclude(c => c.CarManufacturer)
                .ToListAsync(cancellationToken);

            drivers = sortBy switch
            {
                "LastName" => drivers.OrderBy(d => d.LastName).ToList(),
                "Birthday" => drivers.OrderBy(d => d.Birthday).ToList(),
                _ => drivers.OrderBy(d => d.FirstName).ToList(),
            };

            var driverDtos = drivers.Select(d => new DriverDto
            {
                FirstName = d.FirstName,
                LastName = d.LastName,
                Birthday = d.Birthday,
                Car = new CarDto
                {
                    CarNumber = d.Car.Number,
                    ManufacturerName = d.Car.CarManufacturer.Name,
                    ModelName = d.Car.ModelName
                }
            }).ToList();

            return Ok(driverDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DriverDto>> GetDriverById(int id, CancellationToken cancellationToken = default)
        {
            var driver = await _context.Drivers
                .Include(d => d.Car)
                .ThenInclude(c => c.CarManufacturer)
                .FirstOrDefaultAsync(d => d.Id == id, cancellationToken);

            if (driver == null)
            {
                return NotFound(new { Message = "Driver not found" });
            }

            var driverDto = new DriverDto
            {
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Birthday = driver.Birthday,
                Car = new CarDto
                {
                    CarNumber = driver.Car.Number,
                    ManufacturerName = driver.Car.CarManufacturer.Name,
                    ModelName = driver.Car.ModelName
                }
            };

            return Ok(driverDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDriver(CreateDriverDto createDriverDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var car = await _context.Cars.FindAsync(new object[] { createDriverDto.CarId }, cancellationToken);
                if (car == null)
                {
                    return BadRequest(new { Message = "Invalid CarId. Car not found." });
                }

                var driver = new Driver
                {
                    FirstName = createDriverDto.FirstName,
                    LastName = createDriverDto.LastName,
                    Birthday = createDriverDto.Birthday,
                    CarId = createDriverDto.CarId,
                    ConcurrencyToken = new byte[8] 
                };

                _context.Drivers.Add(driver);
                await _context.SaveChangesAsync(cancellationToken);

                return CreatedAtAction(nameof(GetDriverById), new { id = driver.Id }, driver);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the driver");
                return StatusCode(500, new { title = "Internal server error. Please retry later.", status = 500 });
            }
        }

        [HttpGet("competitions")]
        public async Task<ActionResult<IEnumerable<Competition>>> GetCompetitions()
        {
            var comps = await _context.Competitions.ToListAsync();

            return comps.ToList();
        }

        [HttpPost("competitions")]
        public async Task<IActionResult> AssignDriverToCompetition([FromBody] AssignDriverToCompetitionDto dto, CancellationToken cancellationToken = default)
        {
                var driver = await _context.Drivers.FindAsync(new object[] { dto.DriverId }, cancellationToken);
                if (driver == null)
                {
                    return NotFound(new { Message = "Driver not found." });
                }

                var competition = await _context.Competitions.FindAsync(new object[] { dto.CompetitionId }, cancellationToken);
                if (competition == null)
                {
                    return NotFound(new { Message = "Competition not found." });
                }

                var driverCompetition = new DriverCompetition
                {
                    DriverId = dto.DriverId,
                    CompetitionId = dto.CompetitionId,
                    Date = DateTime.UtcNow 
                };

                _context.DriverCompetitions.Add(driverCompetition);
                await _context.SaveChangesAsync(cancellationToken);

                return Ok(new { Message = "Driver assigned to competition successfully." });
        }
    }
}
