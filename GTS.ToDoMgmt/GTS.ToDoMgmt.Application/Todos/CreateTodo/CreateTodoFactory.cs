using GTS.ToDoMgmt.Application.Todos.Dtos;
using GTS.ToDoMgmt.Domain.Todos;

namespace GTS.ToDoMgmt.Application.Todos.CreateTodo
{
    public interface ICreateTodoFactory
    {
        Todo GetTodoEntity(TodoDto todoDto);
    }

    public class CreateTodoFactory : ICreateTodoFactory
    {
        public Todo GetTodoEntity(TodoDto todoDto)
        {
            var entityStatus = Enum.Parse<TodoStatus>(todoDto.Status.ToString());
            var entityPriority = Enum.Parse<TodoPriority>(todoDto.Priority.ToString());

            Todo entity = Todo.Create(
                todoDto.Title,
                entityStatus,
                entityPriority,
                todoDto.Description,
                todoDto.DueDate
                );

            return entity;
        }
    }
}
