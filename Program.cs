using FluentValidation;
using MediatR;
using OBILET.API.Application.Behaviors;
using OBILET.API.Application.Interfaces;
using OBILET.API.Application.Middlewares;
using OBILET.API.Application.Queries.Journeys;
using OBILET.API.Application.Settings;
using OBILET.API.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.Configure<ObiletApiSettings>(
    builder.Configuration.GetSection("ObiletApi")
);
builder.Services.AddMemoryCache();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


builder.Services.AddValidatorsFromAssemblyContaining<GetJourneysQueryValidator>();

builder.Services.AddHttpClient<IObiletApiClient, ObiletApiClient>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
