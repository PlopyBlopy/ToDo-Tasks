using Microsoft.Extensions.DependencyInjection;
using ToDoTask.DataBases;
using ToDoTask.DataBases.Entitys;
using ToDoTask.DataBases.Repositories;
using ToDoTask.View.UserControls;
using ToDoTask.View.Windows;
using ToDoTask.ViewModels;
using ToDoTask.Models.Interfaces;

namespace ToDoTask.Models
{
    public class RegistrationServices
    {
        public IServiceProvider ServiceConfigure() //static
        {
            var services = new ServiceCollection();

            #region Database Context

            services.AddDbContext<ApplicationSQLliteContext>();

            #endregion Database Context

            #region Database Entitys

            services.AddTransient<TaskEntity>();
            services.AddScoped<GroupEntity>();

            #endregion Database Entitys

            #region Repositories

            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();

            #endregion Repositories

            #region Windows

            services.AddTransient<MainWindow>();
            services.AddTransient<CreateTaskWindow>();
            services.AddTransient<CreateGroupWindow>();
            services.AddTransient<TaskMenuUC>();

            #endregion Windows

            #region ViewModels

            services.AddTransient<GroupsStorageVM>();
            services.AddTransient<OpenWindowVM>();
            services.AddTransient<GroupItemVM>();
            services.AddScoped<GroupsComboBoxVM>();

            services.AddTransient<CreateTaskVM>();
            services.AddScoped<TaskVM>();
            services.AddScoped<TaskValidationVM>();

            services.AddTransient<CreateGroupVM>();
            services.AddScoped<GroupVM>();
            services.AddScoped<GroupValidationVM>();

            #endregion ViewModels

            #region Models

            services.AddSingleton<GroupsStorageModel>();

            services.AddTransient<GroupItemModel>();
            services.AddScoped<GroupsComboBoxModel>();

            services.AddTransient<TaskModel>();
            services.AddTransient<GroupModel>();

            services.AddTransient<TaskValidationModel>();
            services.AddTransient<GroupValidationModel>();

            #endregion Models

            #region Validations

            services.AddTransient<ITitleValidation<TaskEntity>>(provider => new TitleValidation<TaskEntity>(provider.GetRequiredService<ITaskRepository>()));
            services.AddTransient<ITitleValidation<GroupEntity>>(provider => new TitleValidation<GroupEntity>(provider.GetRequiredService<IGroupRepository>()));
            services.AddTransient<IDescriptionValidation, DescriptionValidation>();
            services.AddTransient<IDeadlineValidation, DeadlineValidation>();

            #endregion Validations

            return services.BuildServiceProvider();
        }
    }
}