using AutoMapper;
using FormulaOne.Api.Dtos.Achievements;
using FormulaOne.Api.Dtos.Drivers;
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

            CreateMap<CreateDriverRequestDto, Driver>()
                .ForMember(entity => entity.Id, x => x.MapFrom(dto => dto.DriverId))
                .ForMember(entity => entity.FirstName, x => x.MapFrom(dto => dto.FirstName))
                .ForMember(entity => entity.LastName, x => x.MapFrom(dto => dto.LastName))
                .ForMember(entity => entity.DriverNumber, x => x.MapFrom(dto => dto.DriverNumber))
                .ForMember(entity => entity.DateOfBirth, x => x.MapFrom(dto => dto.DateOfBirth))
                .ForMember(entity => entity.CreatedAt, x => x.MapFrom(dto => DateTime.UtcNow))
                .ForMember(entity => entity.UpdatedAt, x => x.MapFrom(dto => DateTime.UtcNow))
                .ForMember(entity => entity.Status, x => x.MapFrom(dto => 1));

            CreateMap<UpdateDriverRequestDto, Driver>()
                .ForMember(entity => entity.UpdatedAt, x => x.MapFrom(dto => DateTime.UtcNow))
                .ForMember(entity => entity.Id, x => x.MapFrom(dto => dto.DriverId))
                .ForMember(entity => entity.FirstName, x => x.MapFrom(dto => dto.FirstName))
                .ForMember(entity => entity.LastName, x => x.MapFrom(dto => dto.LastName))
                .ForMember(entity => entity.DriverNumber, x => x.MapFrom(dto => dto.DriverNumber))
                .ForMember(entity => entity.DateOfBirth, x => x.MapFrom(dto => dto.DateOfBirth))
                .ForMember(entity => entity.CreatedAt, x => x.MapFrom(dto => DateTime.UtcNow))
                .ForMember(entity => entity.Status, x => x.MapFrom(dto => 1));
        }
    }
}
