using GTS.ToDoMgmt.Application.Todos.Enums;

namespace GTS.ToDoMgmt.Application.Todos.Dtos
{
    public record TodoDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public TodoStatusEnum Status { get; set; }
        public TodoPriorityEnum Priority { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
