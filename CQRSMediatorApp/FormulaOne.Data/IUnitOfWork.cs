using FormulaOne.Data.Repositories.Achievements;
using FormulaOne.Data.Repositories.Drivers;

namespace FormulaOne.Data
{
    public interface IUnitOfWork
    {
        IDriverRepo Drivers { get; }
        IAchievementRepo Achievements { get; }

        Task CompleteAsync();
    }
}
