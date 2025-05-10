using GTS.ToDoMgmt.Application.Abstractions.Messaging;
using GTS.ToDoMgmt.Application.Exceptions.Application;
using GTS.ToDoMgmt.Domain.Abstractions;
using GTS.ToDoMgmt.Domain.Todos;

namespace GTS.ToDoMgmt.Application.Todos.CompleteTodo
{
    public class CompleteTodoCommandHandler : ICommandHandler<CompleteTodoCommand>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompleteTodoCommandHandler(ITodoRepository todoRepository, IUnitOfWork unitOfWork)
        {
            _todoRepository = todoRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(CompleteTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = await _todoRepository.GetByIdAsync(request.TodoId, cancellationToken);

            if (todo == null)
                throw new UnableToCompleteTodoException("it is not found.");

            if(todo.Status == TodoStatus.Completed)
                throw new UnableToCompleteTodoException("it is already completed.");

            todo.Complete();
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
