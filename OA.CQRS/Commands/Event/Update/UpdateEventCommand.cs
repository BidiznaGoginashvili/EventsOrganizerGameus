using System;
using MediatR;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OA.CQRS.Commands.Event.Update
{
    public class UpdateEventCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrlPath { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CategoryId { get; set; }

        public List<SelectListItem> CategoryIds { get; set; } = new List<SelectListItem>();

        public UpdateEventAddressCommand Address { get; set; } = new UpdateEventAddressCommand();
    }

    public class UpdateEventAddressCommand
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string Location { get; set; }
    }
}
