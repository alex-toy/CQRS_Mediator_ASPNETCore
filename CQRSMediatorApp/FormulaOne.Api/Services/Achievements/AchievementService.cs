﻿using AutoMapper;
using FormulaOne.Data.Repositories.Achievements;
using FormulaOne.Data.UnitOfWorks;
using FormulaOne.Entities.Dtos.Achievements;
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

        public async Task<CreateAchievementResponseDto?> GetDriverAchievementAsync(Guid driverId)
        {
            Achievement? achievement = await _unitOfWork.Achievements.GetDriverAchievementAsync(driverId);
            if (achievement == null) return null;

            return _mapper.Map<Achievement, CreateAchievementResponseDto>(achievement);
        }

        public async Task<Guid> AddAchievement(CreateAchievementRequestDto achievementDto)
        {
            Achievement achievement = _mapper.Map<CreateAchievementRequestDto, Achievement>(achievementDto);
            Guid isSuccess = await _unitOfWork.Achievements.Add(achievement);
            await _unitOfWork.CompleteAsync();

            return isSuccess;
        }

        public async Task<bool> UpdateAchievement(UpdateAchievementRequestDto achievementDto)
        {
            Driver driver = _mapper.Map<UpdateAchievementRequestDto, Driver>(achievementDto);
            bool isSuccess = await _unitOfWork.Drivers.Update(driver);
            await _unitOfWork.CompleteAsync();

            return isSuccess;
        }
    }
}
