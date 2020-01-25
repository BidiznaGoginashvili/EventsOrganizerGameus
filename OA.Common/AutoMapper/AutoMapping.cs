using AutoMapper;
using OA.Domain.Event;
using OA.Domain.Image;
using OA.Domain.Address;
using OA.Domain.Category;
using OA.Common.Listings.Event;

namespace OA.Common.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Event, EventsModel>()
             .ForMember(mod => mod.ImagePath, @event => @event.MapFrom(e => e.Image.UrlPath))
             .ForMember(mod => mod.CategoryName, @event => @event.MapFrom(e => e.Category.Name))
             .ForMember(mod => mod.Address, @event => @event.MapFrom(e => e.Address.Location));

            CreateMap<Category, Category>();
            CreateMap<Address, Address>();
            CreateMap<Image, Image>();
        }
    }
}
