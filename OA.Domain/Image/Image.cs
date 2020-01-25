namespace OA.Domain.Image
{
    public class Image
    {
        public int Id { get; set; }

        public string UrlPath { get; set; }

        public int EventId { get; set; }

        public virtual Event.Event Event { get; set; }
    }
}
