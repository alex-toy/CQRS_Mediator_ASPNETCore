using AutoMapper;
using FormulaOne.Data.Repositories.Drivers;
using FormulaOne.Data.UnitOfWorks;
using FormulaOne.Entities.Dtos.Drivers;
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

        public async Task<Guid> AddDriver(CreateDriverRequestDto driverDto)
        {
            Driver driver = _mapper.Map<CreateDriverRequestDto, Driver>(driverDto);
            var guid = await _unitOfWork.Drivers.Add(driver);
            await _unitOfWork.CompleteAsync();

            return guid;
        }

        public async Task<bool> UpdateDriver(UpdateDriverRequestDto driverDto)
        {
            Driver driver = _mapper.Map<UpdateDriverRequestDto, Driver>(driverDto);
            bool isSuccess = await _unitOfWork.Drivers.Update(driver);
            await _unitOfWork.CompleteAsync();

            return isSuccess;
        }
    }
}
