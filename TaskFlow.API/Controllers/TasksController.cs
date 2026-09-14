using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTO.Tasks;
using TaskFlow.Application.DTOs.Tasks;
using TaskFlow.Application.Interfaces.IUseCases;

using TaskFlow.Application.UseCases.Task;

namespace TaskFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TasksController : ControllerBase
{
    private readonly ICreateTaskUseCase _createTaskUseCase;
    private readonly IGetTasksUseCase _getTasksUseCase;
    private readonly IGetTaskByIdUseCase _getTaskByIdUseCase;
    private readonly IUpdateTaskUseCase _updateTaskUseCase;
    private readonly IDeleteTaskUseCase _deleteTaskUseCase;

    public TasksController(
        ICreateTaskUseCase createTaskUseCase,
        IGetTasksUseCase getTasksUseCase,
        IGetTaskByIdUseCase getTaskByIdUseCase,
        IUpdateTaskUseCase updateTaskUseCase,
        IDeleteTaskUseCase deleteTaskUseCase)
    {
        _createTaskUseCase = createTaskUseCase;
        _getTasksUseCase = getTasksUseCase;
        _getTaskByIdUseCase = getTaskByIdUseCase;
        _updateTaskUseCase = updateTaskUseCase;
        _deleteTaskUseCase = deleteTaskUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateTaskDto createTaskDto)
    {
        var result = await _createTaskUseCase
            .ExecuteAsync(createTaskDto);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _getTasksUseCase
            .ExecuteAsync();

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _getTaskByIdUseCase
            .ExecuteAsync(id);

        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateTaskDto updateTaskDto)
    {
        var result = await _updateTaskUseCase
            .ExecuteAsync(id, updateTaskDto);

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deleteTaskUseCase
            .ExecuteAsync(id);

        return NoContent();
    }
}