using GTS.ToDoMgmt.Domain.Todos.Events;
using MediatR;

namespace GTS.ToDoMgmt.Application.EventHandlers
{
    public class TodoCompletedEventHandler : INotificationHandler<TodoCompletedDomainEvent>
    {
        public async Task Handle(TodoCompletedDomainEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Congrats, Todo : {notification.CompletedTodoId} Completed.");
        }
    }
}
