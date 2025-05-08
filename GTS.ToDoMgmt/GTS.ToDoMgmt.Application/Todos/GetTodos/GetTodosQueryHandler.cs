using GTS.ToDoMgmt.Application.Abstractions.Messaging;
using GTS.ToDoMgmt.Application.Exceptions.Application;
using GTS.ToDoMgmt.Application.Todos.GetTodos.Dtos;
using GTS.ToDoMgmt.Domain.Todos;

namespace GTS.ToDoMgmt.Application.Todos.GetTodos
{
    public class GetTodosQueryHandler : IQueryHandler<GetTodosQuery, GetTodosResponseDto>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IGetTodosFactory _getTodosFactory;

        public GetTodosQueryHandler(ITodoRepository todoRepository, IGetTodosFactory getTodosFactory)
        {
            _todoRepository = todoRepository;
            _getTodosFactory = getTodosFactory;
        }
        public async Task<GetTodosResponseDto> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Todo>? todos;
            if (_getTodosFactory.QueryHasTodoFilters(request))
            {
                var filters = _getTodosFactory.GetEntityFilters(request);
                todos = await _todoRepository.GetByFilterAsync(filters, cancellationToken);
            }
            else
                todos = await _todoRepository.GetByFilterAsync([], cancellationToken);

            if (NoTodosFound(todos))
                throw new TodosNotFoundException();

            return _getTodosFactory.GetTodosResponseDto(request ,todos);
        }

        private static bool NoTodosFound(IEnumerable<Todo>? todos)
        {
            return todos == null || !todos.Any();
        }
    }
}
