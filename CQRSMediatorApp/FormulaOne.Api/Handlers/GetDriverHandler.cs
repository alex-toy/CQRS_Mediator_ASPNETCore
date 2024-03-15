using FormulaOne.Api.Dtos.Drivers;
using FormulaOne.Api.Queries;
using FormulaOne.Api.Services.Drivers;
using MediatR;

namespace FormulaOne.Api.Handlers
{
    public class GetDriverHandler : IRequestHandler<GetDriverQuery, DriverResponseDto?>
    {
        private readonly IDriverService _driverService;

        public GetDriverHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async Task<DriverResponseDto?> Handle(GetDriverQuery request, CancellationToken cancellationToken)
        {
            DriverResponseDto? driverDto = await _driverService.GetDriver(request.DriverId);
            return driverDto;
        }
    }
}
