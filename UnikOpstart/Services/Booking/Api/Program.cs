using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using UnikOpstart.Services.Booking.Domain.Models;
using UnikOpstart.Services.Booking.Application.Commands;
using UnikOpstart.Services.Booking.Application.Commands.Implementations.Booking;
using UnikOpstart.Services.Booking.Application.Queries;
using UnikOpstart.Services.Booking.Application.Queries.Implementations.Booking;
using UnikOpstart.Services.Booking.Application.Repository;
using UnikOpstart.Services.Booking.Application.Dtos.Booking;
using UnikOpstart.Services.Booking.Infrastructure.Repository;
using UnikOpstart.Services.Booking.Database.SqlContext;
using UnikOpstart.Services.Booking.Crosscut.TransactionHandling;
using UnikOpstart.Services.Booking.Crosscut.TransactionHandling.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(uow =>
{
    var db = uow.GetService<BookingContext>();
    return new UnitOfWork(db);
});

builder.Services.AddScoped<IRepositoryBooking, RepositoryBooking>();
builder.Services.AddScoped<ICreateCommand<CreateRequestDtoBooking>, CreateCommandBooking>();
builder.Services.AddScoped<IUpdateCommand<UpdateRequestDtoBooking>, UpdateCommandBooking>();
builder.Services.AddScoped<IDeleteCommand<BookingEntity>, DeleteCommandBooking>();
builder.Services.AddScoped<IGetQuery<QueryResultDtoBooking>, GetQueryBooking>();
builder.Services.AddScoped<IGetAllByMedarbejderIdQuery<QueryResultDtoBooking>, GetAllByMedarbejderIdQueryBooking>();
builder.Services.AddScoped<IGetAvailableMedarbejderQuery, GetAvailableMedarbejderQuery>();

// Database (Features)
builder.Services.AddDbContext<BookingContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BookingsDbConnection"),
        x => x.MigrationsAssembly("SqlMigrations")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
