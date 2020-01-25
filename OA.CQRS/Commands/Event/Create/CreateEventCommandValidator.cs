using FluentValidation;

namespace OA.CQRS.Commands.Event.Create
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator()
        {
            RuleFor(ec => ec.Name).NotEmpty().NotNull().WithMessage("Event name should't be empty");

            RuleFor(ec => ec.CategoryId).NotEqual(0).WithMessage("Category required");
        }
    }
}
