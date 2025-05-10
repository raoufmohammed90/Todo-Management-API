using GTS.ToDoMgmt.Application.Abstractions.Messaging;
using GTS.ToDoMgmt.Application.Exceptions.Application;
using GTS.ToDoMgmt.Domain.Abstractions;
using GTS.ToDoMgmt.Domain.Todos;

namespace GTS.ToDoMgmt.Application.Todos.DeleteTodo
{
    public class DeleteTodoCommandHandler : ICommandHandler<DeleteTodoCommand>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTodoCommandHandler(ITodoRepository todoRepository, IUnitOfWork unitOfWork)
        {
            _todoRepository = todoRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            bool isDeleted = _todoRepository.Delete(request.TodoId);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            if (!isDeleted)
                throw new DeleteFailedException(request.TodoId, "Todo not found");
        }
    }
}
