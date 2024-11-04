using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using ToDoTask.DataBases.Entitys;
using ToDoTask.Models;

namespace ToDoTask.ViewModels
{
    public class GroupVM : INotifyPropertyChanged
    {
        private GroupModel _groupModel;
        private GroupValidationVM _groupValidationVM;

        public string Title
        {
            get { return _groupModel.Title; }
            set
            {
                _groupModel.Title = value;
                _groupValidationVM.TitleError = value;
                OnPropertyChanged();
            }
        }

        public GroupVM(GroupModel groupModel, GroupValidationVM groupValidationVM)
        {
            _groupModel = groupModel;
            _groupValidationVM = groupValidationVM;
        }

        public GroupEntity GetGroup()
        {
            try
            {
                _groupValidationVM.TitleValid.IsValid(Title);

                return _groupModel.GetNewGroup();
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