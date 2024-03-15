using FormulaOne.Api.Dtos.Drivers;

namespace FormulaOne.Api.Services.Drivers
{
    public interface IDriverService
    {
        Task<Guid> AddDriver(CreateDriverRequestDto achievementDto);
        Task<bool> Delete(Guid driverId);
        Task<IEnumerable<DriverResponseDto>?> GetAll();
        Task<DriverResponseDto?> GetDriver(Guid driverId);
        Task<bool> UpdateDriver(UpdateDriverRequestDto driverDto);
    }
}