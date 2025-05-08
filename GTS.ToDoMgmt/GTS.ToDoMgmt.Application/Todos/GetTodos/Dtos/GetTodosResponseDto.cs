using GTS.ToDoMgmt.Application.Todos.Dtos;

namespace GTS.ToDoMgmt.Application.Todos.GetTodos.Dtos
{
    public record GetTodosResponseDto
    {
        public FilterationCriteria? TodoFilters { get; set; }
        public ICollection<TodoDto> Todos { get; set; }
    }
}
