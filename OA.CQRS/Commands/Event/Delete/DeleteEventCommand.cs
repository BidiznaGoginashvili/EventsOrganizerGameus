using MediatR;

namespace OA.CQRS.Commands.Event.Delete
{
    public class DeleteEventCommand : IRequest
    {
        public DeleteEventCommand(int id)
        {
            Id = id;
        }

        public int? Id { get; set; }
    }
}
