using GTS.ToDoMgmt.Application.Todos.Dtos;
using GTS.ToDoMgmt.Application.Todos.UpdateTodo.Dtos;
using GTS.ToDoMgmt.Domain.Todos;

namespace GTS.ToDoMgmt.Application.Todos.UpdateTodo
{
    public interface IUpdateTodoFactory
    {
        void UpdateTodoEntity(Todo todo, UpdateTodoDto todoDto);
    }
    public class UpdateTodoFactory : IUpdateTodoFactory
    {
        public void UpdateTodoEntity(Todo todo, UpdateTodoDto todoDto)
        {
            TodoStatus entityStatus;
            TodoPriority entityPriority;

            bool entityStatusParsed = Enum.TryParse(todoDto.Status.ToString(), out entityStatus);
            bool entityPriorityParsed = Enum.TryParse(todoDto.Priority.ToString(), out entityPriority);

            todo.Update(
                todoDto.Title,
                entityStatusParsed ? entityStatus : null,
                entityPriorityParsed ? entityPriority : null,
                todoDto.Description,
                todoDto.DueDate
                );
        }
    }
}
