using GTS.ToDoMgmt.Application.Abstractions.Messaging;
using GTS.ToDoMgmt.Application.Todos.Dtos;

namespace GTS.ToDoMgmt.Application.Todos.CreateTodo
{
    public record CreateTodoCommand : ICommand
    {
        public TodoDto Todo { get; set; }
    }
}
