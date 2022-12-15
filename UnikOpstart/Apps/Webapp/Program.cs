using Webapp.Infrastructure.Medarbejder.Contract;
using Webapp.Infrastructure.Medarbejder.Contract.Implementation;
using Webapp.Infrastructure.Kunde.Contract;
using Webapp.Infrastructure.Kunde.Contract.Implementation;
using Webapp.Infrastructure.Opgaver.Contract;
using Webapp.Infrastructure.Opgaver.Contract.Implementation;
using Webapp.Infrastructure.Kompetencer.Contract;
using Webapp.Infrastructure.Kompetencer.Contract.Implemenation;
using Webapp.Infrastructure.Projekt.Contract;
using Webapp.Infrastructure.Projekt.Contract.Implementation;
using Webapp.Infrastructure.Features.Booking.Contract;
using Webapp.Infrastructure.Features.Booking.Contract.Implementation;
using Webapp.UserContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("UserContextConnection") ?? throw new InvalidOperationException("Connection string 'UserContextConnection' not found.");

builder.Services.AddDbContext<UserContext>(options =>
    options.UseSqlite(connectionString,
        b => b.MigrationsAssembly("Webapp.UserContext.Migrations")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 5;
        options.Password.RequiredUniqueChars = 0;
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<UserContext>();

// Add services to the container.
builder.Services.AddRazorPages();

// //claim groups
// builder.Services.AddAuthorization(options => {
//     options.AddPolicy("MedarbejderPolicy", policyBuilder => policyBuilder.RequireClaim("role", "Medarbejder"));
//     options.AddPolicy("KundePolicy", policyBuilder => policyBuilder.RequireClaim("role", "Kunde"));
// });

// // Add pages that need authorization
// builder.Services.AddRazorPages(options =>
// {
//     options.Conventions.AuthorizeFolder("/Medarbejder", "MedarbejderPolicy");
// });

// IHttpClientFactory

// MedarbejderKompetancerApi
builder.Services.AddHttpClient<IMedarbejderService, MedarbejderService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["MedarbejderKomptancerApiBaseUrl"]);
});
builder.Services.AddHttpClient<IKompetencerService, KompetencerService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["MedarbejderKomptancerApiBaseUrl"]);
});

// KundeProjekterApi
builder.Services.AddHttpClient<IProjektService, ProjektService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["KundeProjekterApiBaseUrl"]);
});
builder.Services.AddHttpClient<IKundeService, KundeService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["KundeProjekterApiBaseUrl"]);
});
builder.Services.AddHttpClient<IOpgaverService, OpgaverService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["KundeProjekterApiBaseUrl"]);
});

//BookingApi
builder.Services.AddHttpClient<IBookingService, BookingService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["BookingApiBaseUrl"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
