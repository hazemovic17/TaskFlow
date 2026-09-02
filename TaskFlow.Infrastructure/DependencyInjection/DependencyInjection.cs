using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskFlow.Application.Interfaces.Repositories;
using TaskFlow.Application.UseCases;
using TaskFlow.Infrastructure.Persistence;
using TaskFlow.Infrastructure.Repositories;

namespace TaskFlow.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<TaskFlowDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();

        return services;
    }

  


    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<LoginUseCase>();
        services.AddScoped<RegisterUseCase>();

        return services;
    }
}
