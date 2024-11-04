using System.ComponentModel;
using System.Runtime.CompilerServices;
using ToDoTask.DataBases.Entitys;
using ToDoTask.Models;
using ToDoTask.Models.Interfaces;

namespace ToDoTask.ViewModels
{
    public class TaskValidationVM : INotifyPropertyChanged
    {
        private TaskValidationModel _taskValidationModel;
        public ITitleValidation<TaskEntity> TitleValid;
        public IDescriptionValidation DescriptionValid;

        public string TitleError
        {
            get { return _taskValidationModel.TitleError; }
            set
            {
                try
                {
                    TitleValid.IsValid(value);
                    _taskValidationModel.TitleError = string.Empty;
                }
                catch (Exception ex)
                {
                    _taskValidationModel.TitleError = ex.Message;
                }
                OnPropertyChanged();
            }
        }

        public string DescriptionError
        {
            get { return _taskValidationModel.DescriptionError; }
            set
            {
                try
                {
                    DescriptionValid.IsValid(value);
                    _taskValidationModel.DescriptionError = string.Empty;
                }
                catch (Exception ex)
                {
                    _taskValidationModel.DescriptionError = ex.Message;
                }
                OnPropertyChanged();
            }
        }

        public TaskValidationVM(TaskValidationModel taskValidationModel, ITitleValidation<TaskEntity> titleValidation, IDescriptionValidation descriptionValidation)
        {
            _taskValidationModel = taskValidationModel;
            TitleValid = titleValidation;
            DescriptionValid = descriptionValidation;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}