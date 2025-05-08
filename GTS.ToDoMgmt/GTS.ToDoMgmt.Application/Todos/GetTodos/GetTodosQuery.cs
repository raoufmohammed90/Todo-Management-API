using GTS.ToDoMgmt.Application.Abstractions.Messaging;
using GTS.ToDoMgmt.Application.Todos.GetTodos.Dtos;

namespace GTS.ToDoMgmt.Application.Todos.GetTodos
{
    public record GetTodosQuery : IQuery<GetTodosResponseDto>
    {
        public FilterationCriteria? TodoFilters { get; set; }
    }
}
