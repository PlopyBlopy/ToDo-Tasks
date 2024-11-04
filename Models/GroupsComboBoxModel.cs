using System.Collections.ObjectModel;
using ToDoTask.DataBases.Entitys;

namespace ToDoTask.Models
{
    public class GroupsComboBoxModel
    {
        public ObservableCollection<GroupEntity> Groups { get; private set; }
        public GroupEntity SelectedGroup { get; set; }

        public GroupsComboBoxModel(GroupsStorageModel groupsModel)
        {
            Groups = new ObservableCollection<GroupEntity>(groupsModel.Groups.Select(g => g.Group));
            SelectedGroup = Groups[0];
        }
    }
}