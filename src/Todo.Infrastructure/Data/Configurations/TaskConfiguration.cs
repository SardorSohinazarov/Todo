using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Enums;
using Task = Todo.Domain.Entities.Task;

namespace Todo.Infrastructure.Data.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("Tasks");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(t => t.Description)
                .IsRequired();

            builder.Property(t => t.Deadline)
                .IsRequired();

            builder.Property(t => t.Priority)
                .HasDefaultValue(PriorityLevel.None);

            builder.Property(t => t.State)
                .HasDefaultValue(State.ToDo);

            builder.Property(t => t.Notes)
                .HasMaxLength(1000);

            builder.Property(t => t.CreatedAt)
                .HasDefaultValue(DateTime.Now);
        }
    }
}
