using OA.Domain.Event;
using OA.Domain.Image;
using OA.Domain.Address;
using OA.Domain.Category;
using Microsoft.EntityFrameworkCore;

namespace OA.Repo.Context
{
    public class EventsOrganizationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ToDo : connection string from appsettings
            optionsBuilder.UseLazyLoadingProxies()
                .UseSqlServer("Server=DESKTOP-OKIRIV8; Database=Events; Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Image>()
                    .HasOne<Event>(@event => @event.Event)
                    .WithOne(image => image.Image)
                    .HasForeignKey<Image>(@event => @event.EventId);

            builder.Entity<Address>()
                    .HasOne<Event>(@event => @event.Event)
                    .WithOne(address => address.Address)
                    .HasForeignKey<Address>(@event => @event.EventId);
        }

        public DbSet<Event> Event { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Image> Image { get; set; }

        public DbSet<Address> Address { get; set; }
    }
}
