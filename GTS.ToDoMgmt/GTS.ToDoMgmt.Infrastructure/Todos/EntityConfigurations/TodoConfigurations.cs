using GTS.ToDoMgmt.Domain.Todos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTS.ToDoMgmt.Infrastructure.Todos.EntityConfigurations
{
    internal class TodoConfigurations : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.Property(todo => todo.Title)
                .IsRequired(true)
                .HasMaxLength(100);

            builder.Property(todo => todo.Description)
                .IsRequired(false);

            builder.Property(todo => todo.DueDate)
                .IsRequired(false);

            builder.Property(todo => todo.Status)
                .HasConversion(
                    status => status.ToString(),
                    status => Enum.Parse<TodoStatus>(status)
                );

            builder.Property(todo => todo.Status)
                .HasConversion(
                    priority => priority.ToString(),
                    priority => Enum.Parse<TodoStatus>(priority)
                );
        }
    }
}
