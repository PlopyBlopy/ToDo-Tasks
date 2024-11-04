using System.Windows;
using ToDoTask.ViewModels;

namespace ToDoTask.View.Windows
{
    public partial class CreateTaskWindow : Window
    {
        public CreateTaskVM CreateTaskVM { get; set; }
        public TaskVM TaskVM { get; set; }
        public TaskValidationVM TaskValidationVM { get; set; }
        public GroupsComboBoxVM GroupsComboBoxVM { get; set; }

        public CreateTaskWindow(CreateTaskVM createTaskVM, TaskValidationVM taskValidationVM, TaskVM taskVM, GroupsComboBoxVM groupsComboBoxVM)
        {
            CreateTaskVM = createTaskVM;
            TaskValidationVM = taskValidationVM;
            TaskVM = taskVM;
            GroupsComboBoxVM = groupsComboBoxVM;

            this.DataContext = this;

            InitializeComponent();
        }
    }
}