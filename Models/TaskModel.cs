using ToDoTask.DataBases.Entitys;

namespace ToDoTask.Models
{
    public class TaskModel
    {
        public bool Completed { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Deadline { get; set; } = DateTime.Now;

        private GroupsComboBoxModel _groupsComboBoxModel;

        public TaskModel(GroupsComboBoxModel groupsComboBoxModel)
        {
            _groupsComboBoxModel = groupsComboBoxModel;
        }

        public TaskEntity GetNewTask()
        {
            return new TaskEntity()
            {
                Completed = Completed,
                Title = Title,
                Description = Description,
                Deadline = Deadline,
                GroupEntity = _groupsComboBoxModel.SelectedGroup
            };
        }
    }
}