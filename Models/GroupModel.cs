using ToDoTask.DataBases.Entitys;

namespace ToDoTask.Models
{
    public class GroupModel
    {
        public string Title { get; set; } = string.Empty;

        public GroupEntity GetNewGroup()
        {
            return new GroupEntity()
            {
                Title = Title,
            };
        }
    }
}