using System.Windows.Input;
using ToDoTask.Models;
using ToDoTask.DataBases.Entitys;
using ToDoTask.Commands;

namespace ToDoTask.ViewModels
{
    public class CreateTaskVM
    {
        private ITaskRepository _taskRepository;
        private TaskVM _taskVM;

        public ICommand CreateTaskCommand { get; set; }

        public CreateTaskVM(TaskVM taskVM, ITaskRepository taskRepository)
        {
            _taskVM = taskVM;
            _taskRepository = taskRepository;
            CreateTaskCommand = new CreateTaskCommand(CreateTask, CanCreateTask);
        }

        private async void CreateTask()
        {
            var task = _taskVM.GetTask();
            if (task != null)
            {
                await _taskRepository.AddAsync(task);  // _ = _taskRepository.AddAsync(task);
                WindowManager.Instance.CloseCurrentFloatWindow();
            }
        }

        private bool CanCreateTask()
        {
            return true;
        }
    }
}