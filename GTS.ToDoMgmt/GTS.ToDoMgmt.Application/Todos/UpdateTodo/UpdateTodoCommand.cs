using GTS.ToDoMgmt.Application.Abstractions.Messaging;
using GTS.ToDoMgmt.Application.Todos.UpdateTodo.Dtos;

namespace GTS.ToDoMgmt.Application.Todos.UpdateTodo
{
    public record UpdateTodoCommand : ICommand
    {
        public UpdateTodoDto Todo { get; set; }
    }
}
