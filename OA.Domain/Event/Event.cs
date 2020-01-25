using System;

namespace OA.Domain.Event
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CategoryId { get; set; }

        public virtual Category.Category Category { get; set; }

        public virtual Image.Image Image { get; set; }

        public virtual Address.Address Address { get; set; }
    }
}
