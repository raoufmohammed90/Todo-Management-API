using GTS.ToDoMgmt.Domain.Abstractions;
using GTS.ToDoMgmt.Domain.Todos;
using GTS.ToDoMgmt.Infrastructure.Todos.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GTS.ToDoMgmt.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodoManagementDbContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("TodoMamagementDatabase"),
                    ServerVersion.AutoDetect(configuration.GetConnectionString("TodoMamagementDatabase"))
                )
            );
            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
