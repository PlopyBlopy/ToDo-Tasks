using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ToDoTask.Models;

namespace ToDoTask.ViewModels
{
    public class GroupsStorageVM : INotifyPropertyChanged
    {
        private GroupsStorageModel _groupsStorageModel;
        private ObservableCollection<GroupItemVM> _groups;

        public ObservableCollection<GroupItemVM> Groups
        {
            get => _groups;
            set
            {
                _groups = value;
                OnPropertyChanged();
            }
        }

        public GroupsStorageVM(GroupsStorageModel groupsStorageModel)
        {
            _groupsStorageModel = groupsStorageModel;
            LoadGroups();
        }

        private void LoadGroups()
        {
            var groups = _groupsStorageModel.Groups;
            if (groups != null)
            {
                Groups = new ObservableCollection<GroupItemVM>(groups.Select(g => new GroupItemVM(g)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}