using AutoMapper;
using FormulaOne.Api.Dtos.Drivers;
using FormulaOne.Data.Repositories.Drivers;
using FormulaOne.Data.UnitOfWorks;
using FormulaOne.Entities.Entities;

namespace FormulaOne.Api.Services.Drivers
{
    public class DriverService : BaseService, IDriverService
    {
        private readonly IDriverRepo _driverRepo;

        public DriverService(IDriverRepo driverRepo, IUnitOfWork unitOfWork, IMapper _mapper) : base(_mapper, unitOfWork)
        {
            _driverRepo = driverRepo;
        }

        public async Task<IEnumerable<DriverResponseDto>?> GetAll()
        {
            IEnumerable<Driver>? drivers = await _unitOfWork.Drivers.GetAll();
            if (drivers is null) return null;

            return _mapper.Map<IEnumerable<DriverResponseDto>>(drivers);
        }

        public async Task<DriverResponseDto?> GetDriver(Guid driverId)
        {
            Driver? driver = await _unitOfWork.Drivers.GetById(driverId);
            if (driver is null) return null;

            return _mapper.Map<DriverResponseDto>(driver);
        }

        public async Task<Guid> AddDriver(CreateDriverRequestDto driverDto)
        {
            Driver driver = _mapper.Map<Driver>(driverDto);
            Guid guid = await _unitOfWork.Drivers.Add(driver);
            await _unitOfWork.CompleteAsync();

            return guid;
        }

        public async Task<bool> UpdateDriver(UpdateDriverRequestDto driverDto)
        {
            Driver driver = _mapper.Map<Driver>(driverDto);
            bool isSuccess = await _unitOfWork.Drivers.Update(driver);
            await _unitOfWork.CompleteAsync();

            return isSuccess;
        }

        public async Task<bool> Delete(Guid driverId)
        {
            Driver? driver = await _unitOfWork.Drivers.GetById(driverId);

            if (driver is null) return false;

            bool isSuccess = await _unitOfWork.Drivers.Delete(driverId);
            await _unitOfWork.CompleteAsync();

            return isSuccess;
        }
    }
}
