using BlazorTasks.API.Repositories;

namespace BlazorTasks.API.Configuration
{
    public static class ServiceConfigurationExtension
    {
        public static void AddServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<TaskRepository>();
        }
    }
}
