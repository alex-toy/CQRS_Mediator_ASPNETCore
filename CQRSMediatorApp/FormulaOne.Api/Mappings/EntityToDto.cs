using AutoMapper;
using FormulaOne.Entities.Dtos;
using FormulaOne.Entities.Entities;

namespace FormulaOne.Api.Mappings
{
    public class EntityToDto : Profile
    {
        public EntityToDto()
        {
            CreateMap<Achievement, CreateAchievementResponseDto>()
                 .ForMember(dto => dto.RaceWins, x => x.MapFrom(entity => entity.RaceWins));

            CreateMap<Achievement, UpdateAchievementRequestDto>()
                .ForMember(dto => dto.RaceWins, x => x.MapFrom(entity => entity.RaceWins));

            CreateMap<Achievement, DriverAchievementResponseDto>()
                .ForMember(dto => dto.RaceWins, x => x.MapFrom(entity => entity.RaceWins));
        }
    }
}
