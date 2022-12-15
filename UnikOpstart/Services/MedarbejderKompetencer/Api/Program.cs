using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using UnikOpstart.Services.MedarbejderKompetencer.Domain.Models;
using UnikOpstart.Services.MedarbejderKompetencer.Domain.DomainServices;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.Kompetence;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.Medarbejder;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Commands;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Commands.Implementations.Kompetence;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Commands.Implementations.Medarbejder;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Queries;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Queries.Implementations.Kompetence;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Queries.Implementations.Medarbejder;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Repositories;
using UnikOpstart.Services.MedarbejderKompetencer.Infrastructure.Repositories.Implementations;
using UnikOpstart.Services.MedarbejderKompetencer.Infrastructure.DomainServices.Implementations;
using UnikOpstart.Services.MedarbejderKompetencer.Crosscut.TransactionHandling;
using UnikOpstart.Services.MedarbejderKompetencer.Crosscut.TransactionHandling.Implementation;
using UnikOpstart.Services.MedarbejderKompetencer.Database.SqlContext;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.MedarbejderKomp;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Commands.Implementations.MedarbejderKomp;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Queries.Implementations.MedarbejderKomp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Medarbejder
builder.Services.AddScoped<ICreateCommand<CreateRequestDtoMedarbejder>, CreateCommandMedarbejder>();
builder.Services.AddScoped<IGetQuery<QueryResultDtoMedarbejder>, GetQueryMedarbejder>();
builder.Services.AddScoped<IGetAllQuery<QueryResultDtoMedarbejder>, GetAllQueryMedarbejder>();
builder.Services.AddScoped<IUpdateCommand<UpdateRequestDtoMedarbejder>, UpdateCommandMedarbejder>();
builder.Services.AddScoped<IDeleteCommand<MedarbejderEntity>, DeleteCommandMedarbejder>();
builder.Services.AddScoped<IRepositoryMedarbejder, RepositoryMedarbejder>();
builder.Services.AddScoped<IDomainServiceMedarbejder, DomainServiceMedarbejder>();
builder.Services.AddScoped<IGetAllByKompetenceIdQueryMedarbejder, GetAllByKompetenceIdQueryMedarbejder>();

// Kompetence
builder.Services.AddScoped<ICreateCommand<CreateRequestDtoKompetence>, CreateCommandKompetence>();
builder.Services.AddScoped<IUpdateCommand<UpdateRequestDtoKompetence>, UpdateCommandKompetence>();
builder.Services.AddScoped<IDeleteCommand<KompetenceEntity>, DeleteCommandKompetence>();
builder.Services.AddScoped<IGetQuery<QueryResultDtoKompetence>, GetQueryKompetence>();
builder.Services.AddScoped<IGetAllQuery<QueryResultDtoKompetence>, GetAllQueryKompetence>();
builder.Services.AddScoped<IGetByEgenskabQueryKompetence, GetByEgenskabQueryKompetence>();
builder.Services.AddScoped<IRepositoryKompetence, RepositoryKompetence>();
builder.Services.AddScoped<IDomainServiceKompetence, DomainServiceKompetence>();

// MedarbejderKomp
builder.Services.AddScoped<IRepositoryMedarbejderKomp, RepositoryMedarbejderKomp>();
builder.Services.AddScoped<ICreateCommand<CreateRequestDtoMedarbejderKomp>, CreateCommandMedarbejderKomp>();
builder.Services.AddScoped<IDeleteCommand<MedarbejderKompEntity>, DeleteCommandMedarbejderKomp>();
builder.Services.AddScoped<IGetAllByMedarbejderIdQueryKompetence, GetAllByMedarbejderIdQueryKompetence>();
builder.Services.AddScoped<IGetAllByKompetenceIdQueryMedarbejder, GetAllByKompetenceIdQueryMedarbejder>();

// Database (Features)
builder.Services.AddDbContext<MedarbejderKompetencerContext>(
    options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("MedarbejderKompetenceDbConnection"),
            x => x.MigrationsAssembly("SqlMigrations")));

// Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(p =>
{
    var db = p.GetService<MedarbejderKompetencerContext>();
    return new UnitOfWork(db);
});

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