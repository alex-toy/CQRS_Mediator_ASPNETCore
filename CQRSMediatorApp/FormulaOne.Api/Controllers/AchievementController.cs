using AutoMapper;
using FormulaOne.Api.Services.Achievements;
using FormulaOne.Data.UnitOfWorks;
using FormulaOne.Entities.Dtos.Achievements;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AchievementController : BaseController
    {
        private readonly IAchievementService _achievementService;

        public AchievementController(IUnitOfWork unitOfWork, IMapper mapper, IAchievementService achievementService) : base(unitOfWork, mapper)
        {
            _achievementService = achievementService;
        }

        [HttpGet]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> GetDriverAchievements(Guid driverId)
        {
            CreateAchievementResponseDto? achievementDto;
            try
            {
                achievementDto = await _achievementService.GetDriverAchievementAsync(driverId);

                if (achievementDto is null) return Ok("no achievement found");
            }
            catch (Exception)
            {

                throw;
            }

            return Ok(achievementDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddAchievement([FromBody] CreateAchievementRequestDto achievementDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                Guid guid = await _achievementService.AddAchievement(achievementDto);

                return CreatedAtAction(nameof(AddAchievement), guid != Guid.Empty ? guid : "add achievement failure");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAchievement([FromBody] UpdateAchievementRequestDto driverDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                bool isSuccess = await _achievementService.UpdateAchievement(driverDto);

                return Ok(isSuccess ? "update achievement success" : "update achievement failure");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
