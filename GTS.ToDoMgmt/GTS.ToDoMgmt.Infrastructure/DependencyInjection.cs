using GTS.ToDoMgmt.Application.Abstractions.Messaging;
using GTS.ToDoMgmt.Application.Todos.CreateTodo;
using GTS.ToDoMgmt.Application.Todos.UpdateTodo;
using FluentValidation;
using GTS.ToDoMgmt.Domain.Abstractions;
using GTS.ToDoMgmt.Domain.Todos;
using GTS.ToDoMgmt.Infrastructure.Todos.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GTS.ToDoMgmt.Application.Todos.GetTodos;

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

            services.AddScoped<IUpdateTodoFactory, UpdateTodoFactory>();
            services.AddScoped<ICreateTodoFactory, CreateTodoFactory>();
            services.AddScoped<IGetTodosFactory, GetTodosFactory>();

            services.AddMediatR(
                conf => conf.RegisterServicesFromAssemblies(typeof(ICommand).Assembly)
                );
            services.AddValidatorsFromAssemblyContaining<CreateTodoValidator>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
