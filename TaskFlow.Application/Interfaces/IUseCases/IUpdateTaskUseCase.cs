using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTO.Tasks;

namespace TaskFlow.Application.Interfaces.IUseCases
{

    public interface IUpdateTaskUseCase
    {
        Task<TaskDto> ExecuteAsync(
            Guid id,
            UpdateTaskDto updateTaskDto);
        // 2 params one for id of task and one for what you are going to change in the task
    }
}
