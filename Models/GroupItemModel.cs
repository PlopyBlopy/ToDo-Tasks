using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ToDoTask.DataBases.Entitys;

namespace ToDoTask.Models
{
    public class GroupItemModel
    {
        public bool IsExpanded { get; set; }
        public GroupEntity Group { get; set; }

        public ObservableCollection<TaskEntity> Tasks { get; set; }

        private IGroupRepository _groupRepository;

        public GroupItemModel(IGroupRepository groupRepository, GroupEntity group)
        {
            _groupRepository = groupRepository;
            Group = group;
            //SetGroup(group.Id).GetAwaiter();
        }

        private async Task SetGroup(int id)
        {
            var group = await _groupRepository.GetByIdAsync(id);

            if (group != null)
            {
                Group = group;
            }
        }

        public async Task LoadTasks()
        {
            var tasks = (await _groupRepository.GetTasksByGroupIdAsync(Group.Id)).ToList();

            Tasks = new ObservableCollection<TaskEntity>(tasks);
        }

        public void UnLoadTasks()
        {
            Tasks = null!;
        }
    }
}