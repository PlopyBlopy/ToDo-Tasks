using System.Windows.Input;
using ToDoTask.Commands;
using ToDoTask.DataBases.Entitys;
using ToDoTask.Models;

namespace ToDoTask.ViewModels
{
    public class CreateGroupVM
    {
        private IGroupRepository _groupRepository;
        private GroupVM _groupVM;

        public ICommand CreateGroupCommand { get; set; }

        public CreateGroupVM(GroupVM groupVM, IGroupRepository groupRepository)
        {
            _groupVM = groupVM;
            _groupRepository = groupRepository;
            CreateGroupCommand = new CreateGroupCommand(CreateGroup, CanCreateGroup);
        }

        private async void CreateGroup()
        {
            var group = _groupVM.GetGroup();
            if (group != null)
            {
                await _groupRepository.AddAsync(group);  //    _ = _taskRepository.AddAsync(task);
                WindowManager.Instance.CloseCurrentFloatWindow();
            }
        }

        public bool CanCreateGroup()
        {
            return true;
        }
    }
}