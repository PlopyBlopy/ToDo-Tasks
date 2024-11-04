namespace ToDoTask.DataBases.Entitys
{
    public interface IGroupRepository : IRepository<GroupEntity>
    {
        public Task<IEnumerable<TaskEntity>> GetTasksByGroupIdAsync(int groupId);

        public Task<IEnumerable<TaskEntity>> GetTasksByGroupTitleAsync(string groupTitle);
    }
}