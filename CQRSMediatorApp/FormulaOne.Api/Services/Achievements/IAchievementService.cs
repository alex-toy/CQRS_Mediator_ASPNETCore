using FormulaOne.Api.Dtos.Achievements;

namespace FormulaOne.Api.Services.Achievements
{
    public interface IAchievementService
    {
        Task<Guid> AddAchievement(CreateAchievementRequestDto achievementDto);
        Task<bool> UpdateAchievement(UpdateAchievementRequestDto achievementDto);
        Task<CreateAchievementResponseDto?> GetDriverAchievementAsync(Guid driverId);
    }
}