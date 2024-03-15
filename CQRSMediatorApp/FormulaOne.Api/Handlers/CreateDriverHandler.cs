using FormulaOne.Api.Queries;
using FormulaOne.Api.Services.Drivers;
using MediatR;

namespace FormulaOne.Api.Handlers
{
    public class CreateDriverHandler : IRequestHandler<CreateDriverQuery, Guid>
    {
        private readonly IDriverService _driverService;

        public CreateDriverHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async Task<Guid> Handle(CreateDriverQuery request, CancellationToken cancellationToken)
        {
            return await _driverService.AddDriver(request.CreateDriverRequest);
        }
    }
}
