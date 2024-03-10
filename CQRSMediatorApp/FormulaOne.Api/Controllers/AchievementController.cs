using AutoMapper;
using FormulaOne.Api.Services.Achievements;
using FormulaOne.Data.UnitOfWorks;
using FormulaOne.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AchievementController : BaseController
    {
        private readonly IAchievementService _achievementService;
        public AchievementController(IUnitOfWork unitOfWork, IMapper mapper, IAchievementService achievementService) : base(unitOfWork, mapper)
        {
            _achievementService = achievementService;
        }

        [HttpGet]
        [Route("driverId:guid")]
        public async Task<IActionResult> GetDriverAchievements(Guid driverId)
        {
            DriverAchievementDto? achievementDto = await _achievementService.GetDriverAchievementAsync(driverId);

            if (achievementDto is null) return NotFound("no achievement found");

            return Ok(achievementDto);
        }
    }
}
