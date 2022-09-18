using HeadHunter.Database.MongoDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Net;
using HttpClients = HeadHunter.HttpClients;

var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.Console().CreateLogger();

builder.Host.UseSerilog((context, loggerConfiguration) =>
    loggerConfiguration.WriteTo.Console().ReadFrom.Configuration(context.Configuration));

builder.Services.AddSingleton<HttpClients.HttpContext>();
builder.Services.AddMongoDb();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/api/error/unauthorized";
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
        builder.WithOrigins("http://localhost", "http://194-67-67-175.cloudvps.regruhosting.ru", "http://lev4and.ru").AllowAnyMethod()
                .AllowAnyHeader().AllowCredentials());
});

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling =
        Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var problemDetails = new ValidationProblemDetails(context.ModelState);

        var description = string.Join(' ', problemDetails.Errors.ToList().Select(error =>
        {
            return $"{error.Key} {string.Join(", ", error.Value)}";
        }));

        logger.Warning(description);

        return new BadRequestObjectResult(problemDetails);
    };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.ToString());

    options.AddServer(new OpenApiServer()
    {
        Url = "https://localhost:5001"
    });

    options.AddServer(new OpenApiServer()
    {
        Url = "http://lev4and.ru/resource"
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseStatusCodePages(context =>
{
    var response = context.HttpContext.Response;

    if (response.StatusCode == (int)HttpStatusCode.BadRequest)
    {
        response.Redirect("/api/error/bagRequest");
    }

    return Task.CompletedTask;
});

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.MapControllers();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "api/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapAreaControllerRoute(
        name: "importArea",
        areaName: "Import",
        pattern: "api/import/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapAreaControllerRoute(
        name: "headHunterArea",
        areaName: "HeadHunter",
        pattern: "api/headHunter/{controller=Home}/{action=Index}/{id?}");
});
app.Run();
