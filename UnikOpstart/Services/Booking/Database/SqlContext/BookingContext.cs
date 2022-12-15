using UnikOpstart.Services.Booking.Domain.Models;
using UnikOpstart.Services.Bookings.Database.SqlContext.Configurations;
using Microsoft.EntityFrameworkCore;

namespace UnikOpstart.Services.Booking.Database.SqlContext;
public class BookingContext : DbContext
{
    public BookingContext(DbContextOptions<BookingContext> options) : base(options)
    {
    }

    public DbSet<BookingEntity> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookingTypeConfiguration());
    }
}