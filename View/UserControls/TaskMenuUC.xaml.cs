using System.Windows.Controls;
using ToDoTask.ViewModels;

namespace ToDoTask.View.UserControls
{
    public partial class TaskMenuUC : UserControl
    {
        public GroupsStorageVM GroupsStorageVM { get; set; }

        public TaskMenuUC(GroupsStorageVM groupsStorageVM)
        {
            GroupsStorageVM = groupsStorageVM;
            this.DataContext = this;

            InitializeComponent();
        }
    }
}