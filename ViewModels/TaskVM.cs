using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using ToDoTask.DataBases.Entitys;
using ToDoTask.Models;

namespace ToDoTask.ViewModels
{
    public class TaskVM : INotifyPropertyChanged
    {
        private TaskModel _taskmodel;
        private TaskValidationVM _taskValidationVM;

        public bool Completed
        {
            get { return _taskmodel.Completed; }
            set
            {
                _taskmodel.Completed = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get { return _taskmodel.Title; }
            set
            {
                _taskmodel.Title = value;
                _taskValidationVM.TitleError = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return _taskmodel.Description; }
            set
            {
                _taskmodel.Description = value;
                _taskValidationVM.DescriptionError = value;
                OnPropertyChanged();
            }
        }

        public DateTime Deadline
        {
            get { return _taskmodel.Deadline; }
            set
            {
                _taskmodel.Deadline = value;
                OnPropertyChanged();
            }
        }

        public TaskVM(TaskModel taskModel, TaskValidationVM taskValidationVM)
        {
            _taskmodel = taskModel;
            _taskValidationVM = taskValidationVM;
        }

        public TaskEntity GetTask()
        {
            try
            {
                _taskValidationVM.TitleValid.IsValid(Title);
                _taskValidationVM.DescriptionValid.IsValid(Description);

                return _taskmodel.GetNewTask();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}