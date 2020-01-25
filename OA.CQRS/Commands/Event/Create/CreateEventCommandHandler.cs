using MediatR;
using System.Threading;
using OA.Repo.Repository;
using System.Threading.Tasks;

namespace OA.CQRS.Commands.Event.Create
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand>
    {
        #region Fields

        private readonly IRepository<Domain.Event.Event> _eventsRepository;

        #endregion

        #region Ctor

        public CreateEventCommandHandler(IRepository<Domain.Event.Event> eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        #endregion

        #region Handler

        public async Task<Unit> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var @event = new Domain.Event.Event();
            @event.Name = request.Name;
            @event.Description = request.Description;
            @event.Price = request.Price;
            @event.StartDate = request.StartDate;
            @event.EndDate = request.EndDate;
            @event.CategoryId = request.CategoryId;

            #region Image

            @event.Image = new Domain.Image.Image();
            @event.Image.UrlPath = request.ImageUrlPath;

            #endregion

            #region Address

            @event.Address = new Domain.Address.Address();
            @event.Address.Country = request.Address.Country;
            @event.Address.City = request.Address.City;
            @event.Address.Location = request.Address.Location;

            #endregion

            var entity = await _eventsRepository.Add(@event);

            return default;
        }

        #endregion
    }
}
