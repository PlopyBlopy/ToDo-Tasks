using System.ComponentModel;
using System.Windows.Input;
using ToDoTask.DataBases.Entitys;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using ToDoTask.Models;
using ToDoTask.Commands;

namespace ToDoTask.ViewModels
{
    public class GroupItemVM : INotifyPropertyChanged
    {
        private GroupItemModel _groupItemModel;
        private readonly IGroupRepository _groupRepository;

        public ICommand ToggleExpandCommand { get; }

        public bool IsExpanded
        {
            get => _groupItemModel.IsExpanded;
            set
            {
                _groupItemModel.IsExpanded = value;

                if (_groupItemModel.IsExpanded && Tasks == null)
                {
                    _groupItemModel.LoadTasks().GetAwaiter();
                    Tasks = _groupItemModel.Tasks; //TODO change in future
                }
                else
                {
                    _groupItemModel.UnLoadTasks();
                    Tasks = _groupItemModel.Tasks; //TODO change in future
                }
                OnPropertyChanged();
            }
        }

        public GroupEntity Group
        {
            get => _groupItemModel.Group;
            set
            {
                _groupItemModel.Group = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TaskEntity> Tasks
        {
            get => _groupItemModel.Tasks;
            set
            {
                _groupItemModel.Tasks = value;
                OnPropertyChanged();
            }
        }

        public GroupItemVM()
        {
        }

        public GroupItemVM(GroupItemModel groupItemModel)
        {
            _groupItemModel = groupItemModel;

            ToggleExpandCommand = new GroupTasksCommand(ToggleExpand, CanToggleExpand);
        }

        private void ToggleExpand(object parameter)
        {
            IsExpanded = !IsExpanded;
        }

        private bool CanToggleExpand(object parameter)
        {
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}