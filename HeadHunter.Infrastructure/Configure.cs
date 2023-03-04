using FluentValidation;
using HeadHunter.EntityFramework;
using HeadHunter.HttpClients;
using HeadHunter.Infrastructure.Pipelines;
using HeadHunter.MongoDB;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HeadHunter.Infrastructure
{
    public static class Configure
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddMongoDb();
            services.AddHttpClients();
            services.AddEntityFramework();

            services.AddCompression();
            services.AddFactories();

            services.AddMediatR(typeof(Configure).Assembly);
            services.AddValidatorsFromAssembly(typeof(Configure).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipe<,>));
        }
    }
}
