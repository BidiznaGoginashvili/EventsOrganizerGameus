using MediatR;
using System.Threading;
using OA.Repo.Repository;
using System.Threading.Tasks;

namespace OA.CQRS.Commands.Event.Update
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        #region Fields

        private readonly IRepository<OA.Domain.Event.Event> _eventsRepository;

        #endregion

        #region Ctor

        public UpdateEventCommandHandler(IRepository<OA.Domain.Event.Event> eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        #endregion

        #region Handler

        public Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var @event = _eventsRepository.GetById(request.Id);
            @event.Name = request.Name;
            @event.Description = request.Description;
            @event.Price = request.Price;
            @event.StartDate = request.StartDate;
            @event.EndDate = request.EndDate;
            @event.CategoryId = request.CategoryId;

            #region Image

            @event.Image.UrlPath = request.ImageUrlPath;

            #endregion

            #region Address

            @event.Address.Country = request.Address.Country;
            @event.Address.City = request.Address.City;
            @event.Address.Location = request.Address.Location;

            #endregion

            _eventsRepository.Update(@event);

            return Task.FromResult(default(Unit));
        }

        #endregion
    }
}
