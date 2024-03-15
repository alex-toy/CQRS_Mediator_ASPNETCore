using FormulaOne.Entities.DbContexts;
using FormulaOne.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.Data.Generics
{
    public class GenericRepo<T> : IGenericRepo<T> where T : BaseEntity
    {
        public readonly ILogger Logger;
        protected AppDbContext _context;
        internal DbSet<T> _dbSet;

        public GenericRepo(AppDbContext context, ILogger logger)
        {
            _context = context;
            Logger = logger;

            _dbSet = context.Set<T>();
        }

        public virtual async Task<Guid> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity.Id;
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            T? entity = await _dbSet.FirstOrDefaultAsync(d => d.Id == id);
            if (entity == null) return false;
            _dbSet.Remove(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.Where(d => d.Status == 1).AsNoTracking().AsSplitQuery().OrderBy(d => d.CreatedAt).ToListAsync();
        }

        public virtual async Task<T?> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Update(T newEntity)
        {
            T? entityToUpdate = await _dbSet.AsNoTracking().FirstOrDefaultAsync(d => d.Id == newEntity.Id);
            if (entityToUpdate is null) return false;
            entityToUpdate = newEntity as T;
            entityToUpdate.UpdatedAt = DateTime.UtcNow;
            _dbSet.Update(entityToUpdate);
            return true;
        }
    }
}
