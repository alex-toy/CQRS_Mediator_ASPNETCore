using AutoMapper;
using FormulaOne.Api.Dtos.Drivers;
using FormulaOne.Api.Queries;
using FormulaOne.Api.Services.Drivers;
using FormulaOne.Data.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DriverController : BaseController
    {
        private readonly IDriverService _driverService;
        private readonly IMediator _mediator;

        public DriverController(IUnitOfWork unitOfWork, IMapper mapper, IDriverService driverService, IMediator mediator) : base(unitOfWork, mapper)
        {
            _driverService = driverService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<DriverResponseDto>? driverDtos;
            try
            {
                driverDtos = await _mediator.Send(new GetAllDriversQuery());

                if (!driverDtos.Any()) return NotFound("no drivers found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(driverDtos);
        }

        [HttpGet]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> GetDriver(Guid driverId)
        {
            DriverResponseDto? driverDto;
            try
            {
                driverDto = await _driverService.GetDriver(driverId);

                if (driverDto is null) return NotFound("no driver found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(driverDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequestDto driverDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                Guid guid = await _driverService.AddDriver(driverDto);

                return CreatedAtAction(nameof(AddDriver), guid != Guid.Empty ? guid : "add driver failure");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequestDto driverDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                bool isSuccess = await _driverService.UpdateDriver(driverDto);

                return Ok(isSuccess ? "update driver success" : "update driver failure");
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> Delete(Guid driverId)
        {
            bool isSuccess;
            try
            {
                isSuccess = await _driverService.Delete(driverId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(isSuccess);
        }
    }
}
