using HeadHunterAggregator.Infrastructure.Web.Middlewares;
using HeadHunterAggregator.Services.Vacancy;
using HeadHunterAggregator.Services.Vacancy.ConfigurationOptions;

var builder = WebApplication.CreateBuilder(args);

var appSettings = new AppSettings();

builder.Configuration.Bind(appSettings);

builder.Services.AddVacancyModule(appSettings);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.ToString());
});

builder.Services.AddSwaggerGenNewtonsoftSupport();

var app = builder.Build();

app.MigrateVacanciesDb();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.UseMiddleware<AutoWrapJsonResponse>();

app.UseEndpoints(builder =>
{
    _ = builder.MapAreaControllerRoute("importArea", "import", 
        "api/vacancies/import/{controller=Home}/{action=Index}/{id?}");

    _ = builder.MapAreaControllerRoute("headHunterArea", "headHunter",
        "api/vacancies/headHunter/{controller=Home}/{action=Index}/{id?}");
});

app.Run();
