using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoTask.DataBases.Entitys;

namespace ToDoTask.DataBases.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<GroupEntity>
    {
        public void Configure(EntityTypeBuilder<GroupEntity> builder)
        {
            builder.ToTable("Groups").HasKey(x => x.Id);

            builder
                .HasIndex(x => x.Title)
                .IsUnique();
            builder
                .Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .HasMany(t => t.Tasks)
                .WithOne(t => t.GroupEntity)
                .HasForeignKey(t => t.GroupEntityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}