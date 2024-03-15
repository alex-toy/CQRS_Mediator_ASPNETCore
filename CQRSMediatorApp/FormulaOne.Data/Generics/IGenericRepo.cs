namespace FormulaOne.Data.Generics
{
    public interface IGenericRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(Guid id);
        Task<Guid> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(Guid id);
    }
}
