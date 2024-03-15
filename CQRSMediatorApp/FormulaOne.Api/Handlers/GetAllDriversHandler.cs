using FormulaOne.Api.Dtos.Drivers;
using FormulaOne.Api.Queries;
using FormulaOne.Api.Services.Drivers;
using MediatR;

namespace FormulaOne.Api.Handlers
{
    public class GetAllDriversHandler : IRequestHandler<GetAllDriversQuery, IEnumerable<DriverResponseDto>?>
    {
        private readonly IDriverService _driverService;

        public GetAllDriversHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async Task<IEnumerable<DriverResponseDto>?> Handle(GetAllDriversQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<DriverResponseDto>? driverDtos;
            driverDtos = await _driverService.GetAll();
            return driverDtos;
        }
    }
}
