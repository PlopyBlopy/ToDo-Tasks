namespace ToDoTask.DataBases.Entitys
{
    public interface IRepository<T> where T : class
    {
        public Task AddAsync(T entity);

        public Task AddAsync(IEnumerable<T> entities);

        public Task UpdateAsync(int id, Action<T> updatedEntity);

        public Task RemoveAsync(int id);

        public Task<IEnumerable<T>?> GetAllAsync();

        public Task<T?> GetByIdAsync(int id);

        public Task<T?> GetByTitleAsync(string title);
    }
}