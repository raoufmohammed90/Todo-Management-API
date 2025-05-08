using GTS.ToDoMgmt.Application.Todos.Dtos;
using GTS.ToDoMgmt.Application.Todos.Enums;
using GTS.ToDoMgmt.Application.Todos.GetTodos.Dtos;
using GTS.ToDoMgmt.Domain.Todos;

namespace GTS.ToDoMgmt.Application.Todos.GetTodos
{
    public interface IGetTodosFactory
    {
        bool QueryHasTodoFilters(GetTodosQuery getTodosQuery);
        List<Func<Todo, bool>> GetEntityFilters(GetTodosQuery getTodosQuery);
        GetTodosResponseDto GetTodosResponseDto(GetTodosQuery request, IEnumerable<Todo>? todos);
    }
    internal class GetTodosFactory : IGetTodosFactory
    {
        public List<Func<Todo, bool>> GetEntityFilters(GetTodosQuery getTodosQuery)
        {
            List<Func<Todo, bool>> filters = [];
            if (getTodosQuery.TodoFilters?.StatusFilter != null)
                filters.Add(todo => todo.Status.ToString() == getTodosQuery.TodoFilters?.StatusFilter.ToString());
            if (getTodosQuery.TodoFilters?.PriorityFilter != null)
                filters.Add(todo => todo.Priority.ToString() == getTodosQuery.TodoFilters?.PriorityFilter.ToString());
            if (getTodosQuery.TodoFilters?.CreationDateFilter != null)
                filters.Add(todo =>
                    todo.CreatedDate >= getTodosQuery.TodoFilters?.CreationDateFilter.From &&
                    todo.CreatedDate <= getTodosQuery.TodoFilters?.CreationDateFilter.To
                );
            if (getTodosQuery.TodoFilters?.ModificationDateFilter != null)
                filters.Add(todo =>
                    todo.LastModifiedDate >= getTodosQuery.TodoFilters?.ModificationDateFilter.From &&
                    todo.LastModifiedDate <= getTodosQuery.TodoFilters?.ModificationDateFilter.To
                );
            return filters;
        }

        public GetTodosResponseDto GetTodosResponseDto(GetTodosQuery request, IEnumerable<Todo>? todos)
        {
            GetTodosResponseDto dto = new GetTodosResponseDto()
            {
                TodoFilters = request.TodoFilters,
                Todos = todos!.Select(todo => new TodoDto
                {
                    Description = todo.Description,
                    DueDate = todo.DueDate,
                    Id = todo.Id,
                    Priority = Enum.Parse<TodoPriorityEnum>(todo.Priority.ToString()),
                    Status = Enum.Parse<TodoStatusEnum>(todo.Status.ToString()),
                    Title = todo.Title
                }).ToArray()
            };
            return dto;
        }

        public bool QueryHasTodoFilters(GetTodosQuery getTodosQuery)
        {
            if (getTodosQuery.TodoFilters is null)
                return false;
            bool hasFilter = false;
            hasFilter = hasFilter || getTodosQuery.TodoFilters.StatusFilter != null;
            hasFilter = hasFilter || getTodosQuery.TodoFilters.PriorityFilter != null;
            hasFilter = hasFilter || getTodosQuery.TodoFilters.CreationDateFilter != null;
            hasFilter = hasFilter || getTodosQuery.TodoFilters.ModificationDateFilter != null;

            return hasFilter;
        }
    }
}
