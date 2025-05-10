using FluentValidation;
using GTS.ToDoMgmt.Application.Todos.Enums;

namespace GTS.ToDoMgmt.Application.Todos.CreateTodo
{
    public class CreateTodoValidator : AbstractValidator<CreateTodoCommand>
    {
        public CreateTodoValidator()
        {
            ValidateTodoTitle();
            ValidateTodoStatus();
            ValidateTodoPriority();
        }

        private void ValidateTodoPriority()
        {
            RuleFor(cmd => cmd.Todo.Priority)
                            .NotEqual(TodoPriorityEnum.None)
                            .WithMessage("Todo Priority is invalid. Please choose a valid priority.");
        }

        private void ValidateTodoStatus()
        {
            RuleFor(cmd => cmd.Todo.Status)
                            .NotEqual(TodoStatusEnum.None)
                            .WithMessage("Todo Status is invalid. Please choose a valid status.");
        }

        private void ValidateTodoTitle()
        {
            RuleFor(cmd => cmd.Todo.Title)
                            .NotEmpty()
                            .WithMessage("Title is required.")
                            .MaximumLength(100)
                            .WithMessage("Title must not exceed 100 characters.");
        }
    }
}
