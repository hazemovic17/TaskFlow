using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTO.Tasks;
using TaskFlow.Application.DTOs.Tasks;

namespace TaskFlow.Application.Interfaces.IUseCases
{
    internal interface ICreateTaskUseCase
    {
        public interface ICreateTaskUseCase
        {
            Task<TaskDto> ExecuteAsync(CreateTaskDto createTaskDto);
        }
    }
}
