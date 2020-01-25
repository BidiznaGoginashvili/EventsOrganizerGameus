using MediatR;
using OA.Common.Listings.Event;
using OA.CQRS.Commands.Event.Update;

namespace OA.CQRS.Queries.Event.ListingById
{
    public class GetEventByIdQuery : IRequest<UpdateEventCommand>
    {
        public GetEventByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

        public EventsModel EventsModel { get; set; } = new EventsModel();
    }
}
