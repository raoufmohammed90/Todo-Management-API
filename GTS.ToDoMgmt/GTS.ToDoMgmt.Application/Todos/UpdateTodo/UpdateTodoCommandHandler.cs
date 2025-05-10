using GTS.ToDoMgmt.Application.Abstractions.Messaging;
using GTS.ToDoMgmt.Application.Exceptions.Application;
using GTS.ToDoMgmt.Domain.Abstractions;
using GTS.ToDoMgmt.Domain.Todos;

namespace GTS.ToDoMgmt.Application.Todos.UpdateTodo
{
    public class UpdateTodoCommandHandler : ICommandHandler<UpdateTodoCommand>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUpdateTodoFactory _updateTodoFactory;

        public UpdateTodoCommandHandler(ITodoRepository todoRepository, 
                                        IUnitOfWork unitOfWork,
                                        IUpdateTodoFactory updateTodoFactory)
        {
            _todoRepository = todoRepository;
            _unitOfWork = unitOfWork;
            _updateTodoFactory = updateTodoFactory;
        }
        public async Task Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var todoEntity = await _todoRepository.GetByIdAsync(request.Todo.Id!);
            if (todoEntity == null) 
                throw new UpdateFailedException(request.Todo.Id, "Todo not found");
            
            _updateTodoFactory.UpdateTodoEntity(todoEntity, request.Todo);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
