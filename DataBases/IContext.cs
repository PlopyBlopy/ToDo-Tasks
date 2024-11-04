using Microsoft.EntityFrameworkCore;
using ToDoTask.DataBases.Entitys;

namespace ToDoTask.DataBases
{
    public interface IContext
    {
        DbSet<TaskEntity> Tasks { get; set; }
        DbSet<GroupEntity> Groups { get; set; }

        DbContextOptions DbContextOptions { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}