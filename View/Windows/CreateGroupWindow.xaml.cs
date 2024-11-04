using System.Windows;
using ToDoTask.ViewModels;

namespace ToDoTask.View.Windows
{
    public partial class CreateGroupWindow : Window
    {
        public CreateGroupVM CreateGroupVM { get; set; }
        public GroupVM GroupVM { get; set; }
        public GroupValidationVM GroupValidationVM { get; set; }

        public CreateGroupWindow(CreateGroupVM createGroupVM, GroupVM groupVM, GroupValidationVM groupValidationVM)
        {
            CreateGroupVM = createGroupVM;
            GroupVM = groupVM;
            GroupValidationVM = groupValidationVM;

            this.DataContext = this;

            InitializeComponent();
        }
    }
}