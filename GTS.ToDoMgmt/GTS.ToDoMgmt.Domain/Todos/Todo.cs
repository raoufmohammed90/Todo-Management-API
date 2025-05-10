using GTS.ToDoMgmt.Domain.Abstractions;
using GTS.ToDoMgmt.Domain.Todos.Events;

namespace GTS.ToDoMgmt.Domain.Todos
{
    public class Todo : BaseEntity
    {
        private Todo()
        {

        }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public TodoStatus Status { get; private set; }
        public TodoPriority Priority { get; private set; }
        public DateTime? DueDate { get; private set; }

        public static Todo Create(
            string title,
            TodoStatus status,
            TodoPriority priority,
            string? description = null,
            DateTime? dueDate = null
            )
        {
            var todoEntity = new Todo()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Status = status,
                Priority = priority,
                Description = description,
                DueDate = dueDate,
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow
            };
            return todoEntity;
        }
        public void Update(
            string? title = null,
            TodoStatus? status = null,
            TodoPriority? priority = null,
            string? description = null,
            DateTime? dueDate = null
            )
        {
            bool isUpdated = false;

            if (title != null) {
                Title = title;
                isUpdated = true;
            }
            if (status != null) {
                Status = (TodoStatus)status;
                isUpdated = true;
            }
            if (priority != null)
            {
                Priority = (TodoPriority)priority;
                isUpdated = true;
            }
            if (description != null) {
                Description = description;
                isUpdated = true;
            }
            if (dueDate != null) {
                DueDate = dueDate;
                isUpdated = true;
            }
            if (isUpdated)
                LastModifiedDate = DateTime.UtcNow;
        }
        public void Complete()
        {
            Status = TodoStatus.Completed;
            RaiseDomainEvent(new TodoCompletedDomainEvent(Id));
        }
    }
}
