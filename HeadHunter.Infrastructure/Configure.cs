using FluentValidation;
using HeadHunter.EntityFramework;
using HeadHunter.HttpClients;
using HeadHunter.Infrastructure.Pipelines;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HeadHunter.Infrastructure
{
    public static class Configure
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddHttpClients();
            services.AddEntityFramework();

            services.AddMediatR(typeof(Configure).Assembly);
            services.AddValidatorsFromAssembly(typeof(Configure).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipe<,>));
        }
    }
}
