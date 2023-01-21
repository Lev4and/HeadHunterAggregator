using AutoWrapper;
using HeadHunter.Infrastructure;
using HeadHunter.ResourceWebApplication.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
builder.Services.AddInfrastructure();
builder.Services.AddApiControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseSerilogLogging();
app.UseHttpsRedirection();
app.UseRouting();
app.UseApiResponseAndExceptionWrapper();
app.UseAuthorization();
app.UseCorsPolicy();
app.MapRoutes();
app.Run();
