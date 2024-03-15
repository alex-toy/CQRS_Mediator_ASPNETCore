using AutoMapper;
using FormulaOne.Api.Services.Drivers;
using FormulaOne.Data.UnitOfWorks;
using FormulaOne.Entities.Dtos.Drivers;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DriverController : BaseController
    {
        private readonly IDriverService _driverService;

        public DriverController(IUnitOfWork unitOfWork, IMapper mapper, IDriverService driverService) : base(unitOfWork, mapper)
        {
            _driverService = driverService;
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
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequestDto driverDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                bool isSuccess = await _driverService.UpdateDriver(driverDto);

                return Ok(isSuccess ? "update driver success" : "update driver failure");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
