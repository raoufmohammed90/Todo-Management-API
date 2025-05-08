using GTS.ToDoMgmt.Domain.Todos;
using GTS.ToDoMgmt.Infrastructure.Todos.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace GTS.ToDoMgmt.Infrastructure
{
    public class TodoManagementDbContext : DbContext
    {
        public TodoManagementDbContext()
        {
            
        }
        public TodoManagementDbContext(DbContextOptions<TodoManagementDbContext> options) : base(options)
        {
            
        }
        public DbSet<Todo> Todos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoConfigurations).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
