using GTS.ToDoMgmt.Application.Abstractions.Messaging;

namespace GTS.ToDoMgmt.Application.Todos.CompleteTodo
{
    public class CompleteTodoCommand : ICommand
    {
        public Guid TodoId { get; set; }
    }
}
