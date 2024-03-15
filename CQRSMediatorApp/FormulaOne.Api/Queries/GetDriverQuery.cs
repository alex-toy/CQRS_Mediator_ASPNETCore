using FormulaOne.Api.Dtos.Drivers;
using MediatR;

namespace FormulaOne.Api.Queries
{
    public record GetDriverQuery(Guid DriverId) : IRequest<DriverResponseDto>
    {
    }
}
