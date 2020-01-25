using MediatR;
using AutoMapper;
using System.Threading;
using OA.Repo.Repository;
using System.Threading.Tasks;

namespace OA.CQRS.Commands.Event.Delete
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IRepository<OA.Domain.Event.Event> _eventsRepository;

        #endregion

        #region Ctor

        public DeleteEventCommandHandler(IRepository<OA.Domain.Event.Event> eventsRepository,
               IMapper mapper)
        {
            _mapper = mapper;
            _eventsRepository = eventsRepository;
        }

        #endregion

        #region Handler

        public Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var @event = _eventsRepository.GetById(request.Id.Value);

            if (@event != null)
            {
                _eventsRepository.Delete(@event);
            }

            return Task.FromResult(default(Unit));
        }

        #endregion
    }
}
