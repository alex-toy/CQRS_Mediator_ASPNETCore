using FormulaOne.Data.Repositories.Achievements;
using FormulaOne.Data.Repositories.Drivers;
using FormulaOne.Entities.DbContexts;
using Microsoft.Extensions.Logging;

namespace FormulaOne.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IDriverRepo Drivers { get; }

        public IAchievementRepo Achievements { get; }

        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            ILogger logger = loggerFactory.CreateLogger("logs");

            Drivers = new DriverRepo(_context, logger);
            Achievements = new AchievementRepo(_context, logger);
        }

        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
