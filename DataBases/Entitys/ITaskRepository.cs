namespace ToDoTask.DataBases.Entitys
{
    public interface ITaskRepository : IRepository<TaskEntity>
    {
        public Task<IEnumerable<TaskEntity>> GetCompletedAsync(bool completed);

        public Task<IEnumerable<TaskEntity>> GetByGroupIdAsync(int groupId);

        public Task<IEnumerable<TaskEntity>> GetByDeadlineAsync(DateTime start, DateTime end);
    }
}