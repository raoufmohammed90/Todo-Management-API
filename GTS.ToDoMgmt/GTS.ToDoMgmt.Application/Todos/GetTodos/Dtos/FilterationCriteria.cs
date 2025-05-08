using GTS.ToDoMgmt.Application.Todos.Enums;

namespace GTS.ToDoMgmt.Application.Todos.GetTodos.Dtos
{
    public record FilterationCriteria
    {
        public TodoStatusEnum? StatusFilter { get; set; }
        public TodoPriorityEnum? PriorityFilter { get; set; }
        public DateRangeFilter? CreationDateFilter { get; set; }
        public DateRangeFilter? ModificationDateFilter { get; set; }
    }
}
