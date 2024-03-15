using FormulaOne.Api.Queries;
using FormulaOne.Api.Services.Drivers;
using MediatR;

namespace FormulaOne.Api.Handlers
{
    public class DeleteDriverHandler : IRequestHandler<DeleteDriverQuery, bool>
    {
        private readonly IDriverService _driverService;

        public DeleteDriverHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async Task<bool> Handle(DeleteDriverQuery request, CancellationToken cancellationToken)
        {
            return await _driverService.Delete(request.DriverId);
        }
    }
}
