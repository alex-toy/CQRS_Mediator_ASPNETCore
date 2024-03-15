using FormulaOne.Entities.Dtos;
using FormulaOne.Entities.Dtos.Drivers;

namespace FormulaOne.Api.Services.Drivers
{
    public interface IDriverService
    {
        Task<Guid> AddDriver(CreateDriverRequestDto achievementDto);
        Task<bool> UpdateDriver(UpdateDriverRequestDto driverDto);
    }
}