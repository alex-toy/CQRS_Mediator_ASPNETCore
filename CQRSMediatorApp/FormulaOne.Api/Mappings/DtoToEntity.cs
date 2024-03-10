using AutoMapper;
using FormulaOne.Entities.Dtos;
using FormulaOne.Entities.Entities;

namespace FormulaOne.Api.Mappings
{
    public class DtoToEntity : Profile
    {
        public DtoToEntity()
        {
            CreateMap<CreateAchievementRequestDto, Achievement>()
                .ForMember(entity => entity.RaceWins, x => x.MapFrom(dto => dto.RaceWins))
                .ForMember(entity => entity.CreatedAt, x => x.MapFrom(dto => DateTime.UtcNow))
                .ForMember(entity => entity.UpdatedAt, x => x.MapFrom(dto => DateTime.UtcNow))
                .ForMember(entity => entity.Status, x => x.MapFrom(dto => 1));

            CreateMap<UpdateAchievementRequestDto, Achievement>()
                .ForMember(entity => entity.RaceWins, x => x.MapFrom(dto => dto.RaceWins))
                .ForMember(entity => entity.UpdatedAt, x => x.MapFrom(dto => DateTime.UtcNow));
        }
    }
}
