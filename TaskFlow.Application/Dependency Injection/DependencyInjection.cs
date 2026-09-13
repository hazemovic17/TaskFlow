using Microsoft.Extensions.DependencyInjection;
using TaskFlow.Application.Interfaces.IUseCases;
using TaskFlow.Application.UseCases.Auth;
using TaskFlow.Application.UseCases.Task;
using TaskFlow.Application.UseCases.Tasks;


namespace TaskFlow.Application;


public static class DependencyInjection
{
    public static IServiceCollection AddUseCases(
        this IServiceCollection services)
    {
        services.AddScoped<IRegisterUseCase, RegisterUseCase>();
        services.AddScoped<ILoginUseCase, LoginUseCase>();

        services.AddScoped<ICreateTaskUseCase, CreateTaskUseCase>();
        services.AddScoped<IGetTasksUseCase, GetTasksUseCase>();
        services.AddScoped<IGetTaskByIdUseCase, GetTaskByIdUseCase>();
        services.AddScoped<IUpdateTaskUseCase, UpdateTaskUseCase>();
        services.AddScoped<IDeleteTaskUseCase, DeleteTaskUseCase>();

        return services;
    }

}
