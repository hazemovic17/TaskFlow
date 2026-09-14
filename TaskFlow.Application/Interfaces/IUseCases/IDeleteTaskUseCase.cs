using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Application.Interfaces.IUseCases
{
    public interface IDeleteTaskUseCase
    {
        Task ExecuteAsync(Guid id);
    }
}
