using FormulaOne.Entities.Dtos;

namespace FormulaOne.Api.Services.Achievements
{
    public interface IAchievementService
    {
        Task<DriverAchievementResponseDto?> GetDriverAchievementAsync(Guid driverId);
    }
}