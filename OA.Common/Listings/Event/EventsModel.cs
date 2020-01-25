using System;

namespace OA.Common.Listings.Event
{
    public class EventsModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ImagePath { get; set; }

        public string CategoryName { get; set; }

        public string Address { get; set; }
    }
}
