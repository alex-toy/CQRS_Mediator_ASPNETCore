using FormulaOne.Entities.DbContexts;
using FormulaOne.Entities.Entities;
using Microsoft.Extensions.Logging;

namespace FormulaOne.Data.Repositories.Drivers
{
    public class DriverRepo : GenericRepo<Driver>, IDriverRepo
    {
        public DriverRepo(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
