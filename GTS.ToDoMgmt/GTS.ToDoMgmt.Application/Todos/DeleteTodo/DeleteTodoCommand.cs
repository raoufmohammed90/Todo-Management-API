
using GTS.ToDoMgmt.Application.Abstractions.Messaging;

namespace GTS.ToDoMgmt.Application.Todos.DeleteTodo
{
    public record DeleteTodoCommand : ICommand
    {
        public Guid TodoId { get; set; }
    }
}
