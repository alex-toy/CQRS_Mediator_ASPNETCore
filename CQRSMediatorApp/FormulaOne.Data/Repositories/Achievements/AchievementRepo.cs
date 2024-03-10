using FormulaOne.Data.Generics;
using FormulaOne.Entities.DbContexts;
using FormulaOne.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.Data.Repositories.Achievements
{
    public class AchievementRepo : GenericRepo<Achievement>, IAchievementRepo
    {
        public AchievementRepo(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<Achievement?> GetDriverAchievementAsync(Guid driverId)
        {
            return await _dbSet.FirstOrDefaultAsync(d => d.DriverId == driverId);

        }
    }
}
