using MediatR;
using AutoMapper;
using System.Linq;
using System.Threading;
using OA.Repo.Repository;
using System.Threading.Tasks;
using OA.Common.Listings.Event;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OA.CQRS.Query.Event.Listing
{
    public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, IEnumerable<EventsModel>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Event.Event> _eventsRepository;

        #endregion

        #region Ctor

        public GetEventsQueryHandler(IMapper mapper,
               IRepository<Domain.Event.Event> eventsRepository)
        {
            _mapper = mapper;
            _eventsRepository = eventsRepository;
        }

        #endregion

        #region Handler

        public async Task<IEnumerable<EventsModel>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            var events = _eventsRepository.GetAll()
                         .Include(@event => @event.Address)
                         .Include(@event => @event.Image)
                         .Include(@event => @event.Category).AsEnumerable();

            if (!string.IsNullOrWhiteSpace(request.Name))
                events = events.Where(@event => @event.Name.Contains(request.Name));
            else if (request.CategoryId.HasValue)
                events = events.Where(@event => @event.Category.Id == request.CategoryId.Value);

            var model = _mapper.Map<IEnumerable<EventsModel>>(events);

            return model;
        }

        #endregion
    }
}
