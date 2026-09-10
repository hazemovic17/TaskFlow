using Microsoft.Extensions.DependencyInjection;
using TaskFlow.Application.UseCases.Auth;
using TaskFlow.Application.UseCases.Task;


namespace TaskFlow.Application;


public static class DependencyInjection
{
    public static IServiceCollection AddUseCases(
        this IServiceCollection services)
    {
        services.AddScoped<LoginUseCase>();
        services.AddScoped<RegisterUseCase>();

        services.AddScoped<CreateTaskUseCase>();
        services.AddScoped<GetTasksUseCase>();
        services.AddScoped<GetTaskByIdUseCase>();
        services.AddScoped<UpdateTaskUseCase>();
        services.AddScoped<DeleteTaskUseCase>();

        return services;
    }
}
