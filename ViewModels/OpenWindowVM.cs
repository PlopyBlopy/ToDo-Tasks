using System.Windows.Input;
using ToDoTask.Commands;
using ToDoTask.Models;

namespace ToDoTask.ViewModels
{
    public class OpenWindowVM
    {
        public ICommand OpenWindowCommand { get; set; }

        public OpenWindowVM()
        {
            OpenWindowCommand = new OpenWindowCommand(OpenWindow, CanOpenWindow);
        }

        private void OpenWindow(object parameter)
        {
            if (parameter is WindowRegistry windowReg)
                WindowManager.Instance.OpenFloatWindow(windowReg);
            else if (parameter is WindowSubRegistry windowSubReg)
                WindowManager.Instance.OpenSubWindow(windowSubReg);
        }

        private bool CanOpenWindow(object parameter)
        {
            return true;
        }
    }
}