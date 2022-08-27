using Serilog;
using HttpClients = HeadHunter.HttpClients;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfiguration) =>
    loggerConfiguration.WriteTo.Console().ReadFrom.Configuration(context.Configuration));

builder.Services.AddSingleton<HttpClients.HttpContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/api/error/unauthorized";
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
        builder.WithOrigins("http://localhost:8080", "http://194-67-67-175.cloudvps.regruhosting.ru").AllowAnyMethod()
                .AllowAnyHeader().AllowCredentials());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.ToString());
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

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
        name: "headHunterArea",
        areaName: "HeadHunter",
        pattern: "api/headHunter/{controller=Home}/{action=Index}/{id?}");
});
app.Run();
