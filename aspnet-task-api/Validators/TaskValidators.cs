using aspnet_task_api.DTOs;
using FluentValidation;

namespace aspnet_task_api.Validators
{
    public class TaskCreateValidator : AbstractValidator<TaskCreateDto>
    {
        public TaskCreateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .Length(2, 120);

            RuleFor(x => x.Description)
                .MaximumLength(2000);

            RuleFor(x => x.DueDate)
                .GreaterThan(DateTime.UtcNow).When(x => x.DueDate.HasValue)
                .WithMessage("Due date must be in the future");
        }
    }

    public class TaskUpdateValidator : AbstractValidator<TaskUpdateDto>
    {
        public TaskUpdateValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .Length(2, 120);

            RuleFor(x => x.Description)
                .MaximumLength(2000);
        }
    }
}
