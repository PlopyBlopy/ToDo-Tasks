using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ToDoTask.DataBases.Entitys;
using ToDoTask.Models;

namespace ToDoTask.ViewModels
{
    public class GroupsComboBoxVM : INotifyPropertyChanged
    {
        private GroupsComboBoxModel _groupsComboBoxModel;

        public ObservableCollection<GroupEntity> Groups
        {
            get => _groupsComboBoxModel.Groups;
        }

        public GroupEntity SelectedGroup
        {
            get => _groupsComboBoxModel.SelectedGroup;
            set
            {
                _groupsComboBoxModel.SelectedGroup = value;
                OnPropertyChanged();
            }
        }

        public GroupsComboBoxVM(GroupsComboBoxModel groupsComboBoxModel)
        {
            _groupsComboBoxModel = groupsComboBoxModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}