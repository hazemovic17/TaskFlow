using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTO.Tasks;

namespace TaskFlow.Application.Interfaces.IUseCases
{

    public interface IGetTaskByIdUseCase
    {
        Task<TaskDto> ExecuteAsync(Guid id);
    }
}
