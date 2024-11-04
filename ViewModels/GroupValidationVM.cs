using System.ComponentModel;
using System.Runtime.CompilerServices;
using ToDoTask.DataBases.Entitys;
using ToDoTask.Models;
using ToDoTask.Models.Interfaces;

namespace ToDoTask.ViewModels
{
    public class GroupValidationVM : INotifyPropertyChanged
    {
        private GroupValidationModel _groupValidationModel;
        public ITitleValidation<GroupEntity> TitleValid;

        public string TitleError
        {
            get { return _groupValidationModel.TitleError; }
            set
            {
                try
                {
                    TitleValid.IsValid(value);
                    _groupValidationModel.TitleError = string.Empty;
                }
                catch (Exception ex)
                {
                    _groupValidationModel.TitleError = ex.Message;
                }
                OnPropertyChanged();
            }
        }

        public GroupValidationVM(GroupValidationModel groupValidationModel, ITitleValidation<GroupEntity> titleValidation)
        {
            _groupValidationModel = groupValidationModel;
            TitleValid = titleValidation;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}