using System.Windows;
using ToDoTask.Models;

namespace ToDoTask
{
    public partial class App : Application
    {
        private Window mainWindow;
        private readonly IServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            RegistrationServices registrationServices = new RegistrationServices();
            var serviceProvider = registrationServices.ServiceConfigure();

            WindowManager.Initialize(serviceProvider, WindowRegistry.MainWindow);
            mainWindow = WindowManager.Instance.CurMainWindow;
        }

        private void MainWindow_Closed(object sender, System.EventArgs e)
        {
            this.Shutdown();
        }
    }
}