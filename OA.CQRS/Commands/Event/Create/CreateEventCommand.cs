using System;
using MediatR;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OA.CQRS.Commands.Event.Create
{
    public class CreateEventCommand : IRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrlPath { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CategoryId { get; set; }

        public List<SelectListItem> CategoryIds { get; set; } = new List<SelectListItem>();

        public CreateEventAddressCommand Address { get; set; } = new CreateEventAddressCommand();
    }

    public class CreateEventAddressCommand
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string Location { get; set; }
    }
}
