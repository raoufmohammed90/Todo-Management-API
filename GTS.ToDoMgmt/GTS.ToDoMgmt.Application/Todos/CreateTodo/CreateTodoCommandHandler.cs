using GTS.ToDoMgmt.Application.Abstractions.Messaging;
using GTS.ToDoMgmt.Domain.Abstractions;
using GTS.ToDoMgmt.Domain.Todos;

namespace GTS.ToDoMgmt.Application.Todos.CreateTodo
{
    public class CreateTodoCommandHandler : ICommandHandler<CreateTodoCommand>
    {
        private readonly ICreateTodoFactory _createTodoFactory;
        private readonly ITodoRepository _todoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTodoCommandHandler(ICreateTodoFactory createTodoFactory ,ITodoRepository todoRepository, IUnitOfWork unitOfWork)
        {
            _createTodoFactory = createTodoFactory;
            _todoRepository = todoRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            Todo todo = _createTodoFactory.GetTodoEntity(request.Todo);

            await _todoRepository.CreateAsync(todo, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
