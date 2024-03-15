using FormulaOne.Api.Dtos.Drivers;
using MediatR;

namespace FormulaOne.Api.Queries
{
    public class GetAllDriversQuery : IRequest<IEnumerable<DriverResponseDto>>
    {
    }
}
