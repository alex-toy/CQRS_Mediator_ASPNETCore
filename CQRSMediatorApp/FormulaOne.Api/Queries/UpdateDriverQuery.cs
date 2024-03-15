using FormulaOne.Api.Dtos.Drivers;
using MediatR;

namespace FormulaOne.Api.Queries
{
    public record UpdateDriverQuery(UpdateDriverRequestDto UpdateDriverRequest) : IRequest<bool>
    {
    }
}
