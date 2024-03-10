using FormulaOne.Data.Generics;
using FormulaOne.Entities.Entities;

namespace FormulaOne.Data.Repositories.Achievements
{
    public interface IAchievementRepo : IGenericRepo<Achievement>
    {
        Task<Achievement?> GetDriverAchievementAsync(Guid driverId);
    }
}
