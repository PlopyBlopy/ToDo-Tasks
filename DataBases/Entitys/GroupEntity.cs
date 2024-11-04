namespace ToDoTask.DataBases.Entitys
{
    public class GroupEntity
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public ICollection<TaskEntity>? Tasks { get; set; }
    }
}