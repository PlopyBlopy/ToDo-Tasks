using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoTask.DataBases.Entitys;

namespace ToDoTask.DataBases.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.ToTable("Tasks").HasKey(x => x.Id);

            builder
                .Property(x => x.Completed)
                .IsRequired();

            builder
                .HasIndex(x => x.Title)
                .IsUnique();
            builder
                .Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(x => x.Description)
                .HasMaxLength(500);

            builder
                .Property(x => x.Deadline)
                .IsRequired();

            builder
                .Property(x => x.GroupEntityId)
                .IsRequired();
        }
    }
}