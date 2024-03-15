using FormulaOne.Api.Dtos.Drivers;
using MediatR;

namespace FormulaOne.Api.Queries
{
    public record CreateDriverQuery(CreateDriverRequestDto CreateDriverRequest) : IRequest<Guid>
    {
    }
}
