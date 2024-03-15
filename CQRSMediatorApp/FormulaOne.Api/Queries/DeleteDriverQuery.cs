using MediatR;

namespace FormulaOne.Api.Queries
{
    public record DeleteDriverQuery(Guid DriverId) : IRequest<bool>
    {
    }
}
