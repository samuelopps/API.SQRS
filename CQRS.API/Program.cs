using CQRS.API.Infrastructure.Output;
using CQRS.API.Infrastructure.Input;
using CQRS.API.Application.Commands;
using CQRS.API.Application.Queries;
using Microsoft.OpenApi.Models;
using CQRS.API.Application.Queries.Handlers;
using CQRS.API.Application.Commands.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureOutput();
builder.Services.AddInfrastructureInput();
builder.Services.AddApplicationCommandService();
builder.Services.AddApplicationQueryService();

builder.Services.AddMvc();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CQRS.API", Version = "v1" });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();