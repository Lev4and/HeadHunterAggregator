using HeadHunter.Database.MongoDb;
using HeadHunter.Database.PostgreSQL;
using HeadHunter.HttpClients;
using HeadHunter.ResourceWebApplication.Extensions;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddHttpClients();
builder.Services.AddPostgreSQL();
builder.Services.AddMongoDb();

builder.Services.ConfigureCookie();

builder.Services.AddCorsPolicy();
builder.Services.AddApiControllers();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var problemDetails = new ValidationProblemDetails(context.ModelState);

        //var description = string.Join(' ', problemDetails.Errors.ToList().Select(error =>
        //{
        //    return $"{error.Key} {string.Join(", ", error.Value)}";
        //}));

        //logger.Warning(description);

        throw new ArgumentNullException();

        //return new BadRequestObjectResult(problemDetails);
    };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.ConfigureCustomExceptionMiddleware();

app.UseStatusCodePage();
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.MapControllers();
app.UseCorsPolicy();
app.UseRouting();
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
