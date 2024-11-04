using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;
using ToDoTask.View.UserControls;
using ToDoTask.View.Windows;

namespace ToDoTask.Models
{
    public enum WindowRegistry
    {
        MainWindow,
        CreateTaskWindow,
        CreateGroupWindow,
    }

    public enum WindowSubRegistry
    {
        MyDaySubWindow,
        TaskSubWindow,
        StatisticSubWindow,
        SettingsSubWindow,
        AboutAppSubWindow
    }

    public abstract class WindowFactory
    {
        public IServiceProvider _serviceProvider;

        protected readonly Dictionary<WindowRegistry, Func<Window>> _windowFactories;
        protected readonly Dictionary<WindowSubRegistry, Func<UserControl>> _windowSubFactories;

        protected WindowFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            _windowFactories = new Dictionary<WindowRegistry, Func<Window>>()
            {
                { WindowRegistry.MainWindow, () =>  _serviceProvider.GetService<MainWindow>()},
                { WindowRegistry.CreateTaskWindow, () => _serviceProvider.GetService<CreateTaskWindow>()},
                { WindowRegistry.CreateGroupWindow, () => _serviceProvider.GetService<CreateGroupWindow>() },
            };

            _windowSubFactories = new Dictionary<WindowSubRegistry, Func<UserControl>>()
            {
                { WindowSubRegistry.MyDaySubWindow,() => new MyDayMenuUC() },
                { WindowSubRegistry.TaskSubWindow, () => _serviceProvider.GetService<TaskMenuUC>() },
                { WindowSubRegistry.StatisticSubWindow, () => new StatisticMenuUC() },
                { WindowSubRegistry.SettingsSubWindow, () => new SettingMenuUC() },
                { WindowSubRegistry.AboutAppSubWindow, () => new AboutAppMenuUC() },
            };
        }
    }
}