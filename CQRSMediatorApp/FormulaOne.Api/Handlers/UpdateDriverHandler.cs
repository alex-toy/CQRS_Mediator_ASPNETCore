using FormulaOne.Api.Queries;
using FormulaOne.Api.Services.Drivers;
using MediatR;

namespace FormulaOne.Api.Handlers
{
    public class UpdateDriverHandler : IRequestHandler<UpdateDriverQuery, bool>
    {
        private readonly IDriverService _driverService;

        public UpdateDriverHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }
        public async Task<bool> Handle(UpdateDriverQuery request, CancellationToken cancellationToken)
        {

            return await _driverService.UpdateDriver(request.UpdateDriverRequest);
        }
    }
}
