using System.Collections.ObjectModel;
using ToDoTask.ViewModels;
using ToDoTask.DataBases.Entitys;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ToDoTask.Models
{
    public class GroupsStorageModel
    {
        private readonly IGroupRepository _groupRepository;

        public ObservableCollection<GroupItemModel> Groups { get; set; }

        public GroupsStorageModel(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
            Groups = new ObservableCollection<GroupItemModel>();
            LoadGroupsAsync().ConfigureAwait(false);
        }

        private async Task LoadGroupsAsync()
        {
            var groups = await _groupRepository.GetAllAsync();
            if (groups != null)
            {
                Groups = new ObservableCollection<GroupItemModel>(groups.Select(g => new GroupItemModel(_groupRepository, g)));
            }
        }

        //private async void UpdateGroups()
        //{
        //}
    }
}