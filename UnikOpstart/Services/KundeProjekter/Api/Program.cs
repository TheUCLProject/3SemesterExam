using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using UnikOpstart.Services.KundeProjekter.Database.SqlContext;
using UnikOpstart.Services.KundeProjekter.Domain.Models;
using UnikOpstart.Services.KundeProjekter.Domain.DomainServices;
using UnikOpstart.Services.KundeProjekter.Application.Repositories;
using UnikOpstart.Services.KundeProjekter.Application.Commands;
using UnikOpstart.Services.KundeProjekter.Application.Commands.Implementations.Kunde;
using UnikOpstart.Services.KundeProjekter.Application.Commands.Implementations.Projekt;
using UnikOpstart.Services.KundeProjekter.Application.Commands.Implementations.Opgave;
using UnikOpstart.Services.KundeProjekter.Application.Commands.Implementations.ProjektOpgave;
using UnikOpstart.Services.KundeProjekter.Application.Queries;
using UnikOpstart.Services.KundeProjekter.Application.Queries.Implementations.Kunde;
using UnikOpstart.Services.KundeProjekter.Application.Queries.Implementations.Projekt;
using UnikOpstart.Services.KundeProjekter.Application.Queries.Implementations.Opgave;
using UnikOpstart.Services.KundeProjekter.Application.Queries.Implementations.ProjektOpgave;
using UnikOpstart.Services.KundeProjekter.Application.Dtos.Kunde;
using UnikOpstart.Services.KundeProjekter.Application.Dtos.Projekt;
using UnikOpstart.Services.KundeProjekter.Application.Dtos.Opgave;
using UnikOpstart.Services.KundeProjekter.Application.Dtos.ProjektOpgave;
using UnikOpstart.Services.KundeProjekter.Infrastructure.DomainServices.Implementations;
using UnikOpstart.Services.KundeProjekter.Infrastructure.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Opgave
builder.Services.AddScoped<IRepositoryOpgave, RepositoryOpgave>();
builder.Services.AddScoped<ICreateCommand<CreateRequestDtoOpgave>, CreateCommandOpgave>();
builder.Services.AddScoped<IGetQuery<QueryResultDtoOpgave>, GetQueryOpgave>();
builder.Services.AddScoped<IGetAllQuery<QueryResultDtoOpgave>, GetAllQueryOpgave>();
builder.Services.AddScoped<IUpdateCommand<UpdateRequestDtoOpgave>, UpdateCommandOpgave>();
builder.Services.AddScoped<IDeleteCommand<OpgaveEntity>, DeleteCommandOpgave>();
builder.Services.AddScoped<IDomainServiceOpgave, DomainServiceOpgave>();
builder.Services.AddScoped<IGetByTitleQueryOpgave, GetByTitleQueryOpgave>();

// Kunde
builder.Services.AddScoped<IRepositoryKunde, RepositoryKunde>();
builder.Services.AddScoped<ICreateCommand<CreateRequestDtoKunde>, CreateCommandKunde>();
builder.Services.AddScoped<IDeleteCommand<KundeEntity>, DeleteCommandKunde>();
builder.Services.AddScoped<IUpdateCommand<UpdateRequestDtoKunde>, UpdateCommandKunde>();
builder.Services.AddScoped<IGetQuery<QueryResultDtoKunde>, GetQueryKunde>();
builder.Services.AddScoped<IGetAllQuery<QueryResultDtoKunde>, GetAllQueryKunde>();

// Projekt
builder.Services.AddScoped<IRepositoryProjekt, RepositoryProjekt>();
builder.Services.AddScoped<ICreateCommand<CreateRequestDtoProjekt>, CreateCommandProjekt>();
builder.Services.AddScoped<IGetQuery<QueryResultDtoProjekt>, GetQueryProjekt>();
builder.Services.AddScoped<IGetAllQuery<QueryResultDtoProjekt>, GetAllQueryProjekt>();
builder.Services.AddScoped<IGetAllProjekterByKundeId, GetAllProjekterByKundeId>();
builder.Services.AddScoped<IUpdateCommand<UpdateRequestDtoProjekt>, UpdateCommandProjekt>();
builder.Services.AddScoped<IDeleteCommand<ProjektEntity>, DeleteCommandProjekt>();
builder.Services.AddScoped<IDomainServiceProjekt, DomainServiceProjekt>();


// ProjektOpgave

builder.Services.AddScoped<IRepositoryProjektOpgave, RepositoryProjektOpgave>();
builder.Services.AddScoped<ICreateCommand<CreateRequestDtoProjektOpgave>, CreateCommandProjektOpgave>();
builder.Services.AddScoped<IDeleteCommand<ProjektOpgaveEntity>, DeleteCommandProjektOpgave>();
builder.Services.AddScoped<IGetAllOpgaverForProjekt, GetAllOpgaverForProjekt>();

// Database
builder.Services.AddDbContext<KundeProjekterContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("KundeProjekterDbConnection"),
        b => b.MigrationsAssembly("SqlMigrations")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Because Docker...
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();