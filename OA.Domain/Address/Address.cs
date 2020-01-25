namespace OA.Domain.Address
{
    public class Address
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Location { get; set; }

        public int EventId { get; set; }

        public virtual Event.Event Event { get; set; }
    }
}
