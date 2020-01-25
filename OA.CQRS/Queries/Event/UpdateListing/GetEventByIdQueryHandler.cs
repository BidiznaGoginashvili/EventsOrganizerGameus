using MediatR;
using AutoMapper;
using System.Threading;
using OA.Repo.Repository;
using System.Threading.Tasks;
using OA.CQRS.Commands.Event.Update;

namespace OA.CQRS.Queries.Event.ListingById
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, UpdateEventCommand>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Event.Event> _eventsRepository;

        #endregion

        #region Ctor

        public GetEventByIdQueryHandler(IMapper mapper,
               IRepository<Domain.Event.Event> eventsRepository)
        {
            _mapper = mapper;
            _eventsRepository = eventsRepository;
        }

        #endregion

        #region Handler

        public async Task<UpdateEventCommand> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var events = _eventsRepository.GetById(request.Id);

            IMapper mapper = MapperConfiguration().CreateMapper();

            var destination = mapper.Map<Domain.Event.Event, UpdateEventCommand>(events);

            return destination;
        }

        #endregion

        #region Mapper

        public MapperConfiguration MapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Domain.Event.Event, UpdateEventCommand>()
                    .ForMember(mod => mod.ImageUrlPath, @event => @event.MapFrom(e => e.Image.UrlPath))
                    .ForMember(mod => mod.CategoryId, @event => @event.MapFrom(e => e.Category.Id))
                    .ForPath(mod => mod.Address.City, @event => @event.MapFrom(e => e.Address.City))
                    .ForPath(mod => mod.Address.Country, @event => @event.MapFrom(e => e.Address.Country))
                    .ForPath(mod => mod.Address.Location, @event => @event.MapFrom(e => e.Address.Location));

                cfg.CreateMap<Domain.Category.Category, Domain.Category.Category>();
                cfg.CreateMap<Domain.Address.Address, Domain.Address.Address>();
                cfg.CreateMap<Domain.Image.Image, Domain.Image.Image>();
            });

            return config;
        }

        #endregion
    }
}
