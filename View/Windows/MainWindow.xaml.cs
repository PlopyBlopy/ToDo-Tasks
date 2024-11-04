using System.Windows;
using ToDoTask.ViewModels;

namespace ToDoTask.View.Windows
{
    public partial class MainWindow : Window
    {
        public OpenWindowVM OpenWindowVM { get; set; }

        public MainWindow(OpenWindowVM openWindowVM)
        {
            OpenWindowVM = openWindowVM;

            this.DataContext = this;
            InitializeComponent();
        }
    }
}