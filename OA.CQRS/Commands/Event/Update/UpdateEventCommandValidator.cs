using FluentValidation;

namespace OA.CQRS.Commands.Event.Update
{
    public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
    {
        public UpdateEventCommandValidator()
        {
            RuleFor(ec => ec.Name).NotEmpty().NotNull().WithMessage("Event name should't be empty");
        }
    }
}
