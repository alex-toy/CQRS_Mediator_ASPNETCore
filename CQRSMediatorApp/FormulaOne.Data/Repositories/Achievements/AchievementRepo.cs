using FormulaOne.Entities.DbContexts;
using FormulaOne.Entities.Entities;
using Microsoft.Extensions.Logging;

namespace FormulaOne.Data.Repositories.Achievements
{
    public class AchievementRepo : GenericRepo<Achievement>, IAchievementRepo
    {
        public AchievementRepo(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public Task<Achievement> GetDriverAchievementAsync(Guid driverId)
        {
            throw new NotImplementedException();
        }
    }
}
