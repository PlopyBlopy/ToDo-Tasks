namespace ToDoTask.DataBases.Entitys
{
    public class TaskEntity
    {
        public int Id { get; set; }

        public bool Completed { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Deadline { get; set; } = DateTime.Now;

        public int GroupEntityId { get; set; }
        public GroupEntity GroupEntity { get; set; }
    }
}