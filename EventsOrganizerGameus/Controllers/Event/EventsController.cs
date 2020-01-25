using MediatR;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using OA.CQRS.Query.Event.Listing;
using OA.CQRS.Commands.Event.Delete;
using OA.CQRS.Commands.Event.Create;
using OA.CQRS.Commands.Event.Update;
using OA.CQRS.Queries.Category.Listing;
using OA.CQRS.Queries.Event.ListingById;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventsOrganizerGameus.Controllers.Event
{
    public class EventsController : Controller
    {
        #region Fields

        private readonly IMediator _mediator;

        #endregion

        #region Ctor

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region ActionResults

        #region Listing

        public async Task<IActionResult> EventsListing()
        {
            GetEventsQuery query = new GetEventsQuery();
            query.EventsModel = await _mediator.Send(query);

            //ToDo : Cache Categories
            GetCategoryQuery categoryCommand = new GetCategoryQuery();
            var categories = await _mediator.Send(categoryCommand);

            query.CategoryIds = categories;

            return View(query);
        }

        [HttpPost]
        public async Task<IActionResult> EventsListing(GetEventsQuery getEventsQuery)
        {
            GetCategoryQuery categoryCommand = new GetCategoryQuery();
            var categories = await _mediator.Send(categoryCommand);

            var query = await _mediator.Send(getEventsQuery);

            var events = new GetEventsQuery()
            {
                Name = getEventsQuery.Name,
                CategoryId = getEventsQuery.CategoryId.Value,
                CategoryIds = categories
            };

            events.EventsModel = query;

            return View(events);
        }

        #endregion

        #region Create

        public async Task<IActionResult> CreateEvent()
        {
            CreateEventCommand model = new CreateEventCommand();

            GetCategoryQuery categoryCommand = new GetCategoryQuery();
            var categories = await _mediator.Send(categoryCommand);

            model.CategoryIds = categories;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventCommand model)
        {
            CreateEventCommand eventCommand = new CreateEventCommand();

            if (ModelState.IsValid)
            {
                await _mediator.Send(model);
            }

            return View(model);
        }

        #endregion

        #region Update

        public async Task<IActionResult> UpdateEvent(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("EventsListing");

            GetCategoryQuery categoryCommand = new GetCategoryQuery();
            var categories = await _mediator.Send(categoryCommand);

            GetEventByIdQuery query = new GetEventByIdQuery(id.Value);

            var @event = await _mediator.Send(query);

            UpdateEventCommand model = new UpdateEventCommand();
            model = @event;
            model.CategoryIds = categories.SelectMany(sl => new List<SelectListItem>
            {
                new SelectListItem{
                    Selected = (sl.Value == model.CategoryId.ToString()),
                    Text = sl.Text,
                    Value = sl.Value
                }
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEvent(UpdateEventCommand model)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(model);
            }

            return RedirectToAction("EventsListing");
        }

        #endregion

        #region Delete

        public async Task<IActionResult> DeleteEvent(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("EventsListing");

            DeleteEventCommand model = new DeleteEventCommand(id.Value);

            await _mediator.Send(model);

            return RedirectToAction("EventsListing");
        }

        #endregion

        #endregion
    }
}