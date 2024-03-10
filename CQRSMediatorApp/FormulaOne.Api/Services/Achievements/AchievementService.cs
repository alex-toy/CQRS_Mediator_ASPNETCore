using AutoMapper;
using FormulaOne.Data.Repositories.Achievements;
using FormulaOne.Data.UnitOfWorks;
using FormulaOne.Entities.Dtos;
using FormulaOne.Entities.Entities;

namespace FormulaOne.Api.Services.Achievements
{
    public class AchievementService : BaseService, IAchievementService
    {
        private readonly IAchievementRepo _achievementRepo;

        public AchievementService(IAchievementRepo achievementRepo, IUnitOfWork unitOfWork, IMapper _mapper) : base(_mapper, unitOfWork)
        {
            _achievementRepo = achievementRepo;
        }

        public async Task<DriverAchievementDto?> GetDriverAchievementAsync(Guid driverId)
        {
            Achievement? achievement = await _unitOfWork.Achievements.GetDriverAchievementAsync(driverId);
            if (achievement == null) return null;

            return _mapper.Map<Achievement, DriverAchievementDto>(achievement);
        }
    }
}
