using MediatR;
using OA.Common.Listings.Event;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace OA.CQRS.Query.Event.Listing
{
    public class GetEventsQuery : IRequest<IEnumerable<EventsModel>>
    {
        [Display(Name = "Event")]
        public string Name { get; set; }

        public int? CategoryId { get; set; }

        public List<SelectListItem> CategoryIds { get; set; } = new List<SelectListItem>();

        public IEnumerable<EventsModel> EventsModel { get; set; } = new List<EventsModel>();
    }
}
