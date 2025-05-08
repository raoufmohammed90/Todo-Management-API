using GTS.ToDoMgmt.Domain.Abstractions;

namespace GTS.ToDoMgmt.Domain.Todos.Events
{
    public record TodoCompletedDomainEvent (Guid CompletedTodoId) : IDomainEvent;

}
