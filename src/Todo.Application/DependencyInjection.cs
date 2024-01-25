using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Services;

namespace Todo.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITasksService, TasksService>();

            return services;
        }
    }
}
