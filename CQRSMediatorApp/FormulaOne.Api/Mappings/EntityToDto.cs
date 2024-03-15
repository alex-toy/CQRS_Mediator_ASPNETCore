using AutoMapper;
using FormulaOne.Entities.Dtos.Achievements;
using FormulaOne.Entities.Dtos.Drivers;
using FormulaOne.Entities.Entities;

namespace FormulaOne.Api.Mappings
{
    public class EntityToDto : Profile
    {
        public EntityToDto()
        {
            CreateMap<Achievement, CreateAchievementResponseDto>()
                .ForMember(dto => dto.RaceWins, x => x.MapFrom(entity => entity.RaceWins));

            CreateMap<Driver, DriverResponseDto>()
                .ForMember(dto => dto.FullName, x => x.MapFrom(entity => $"{entity.FirstName} {entity.LastName}"));
        }
    }
}
