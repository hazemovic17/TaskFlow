using TaskFlow.Application.Interfaces.Repositories;
using System.Threading.Tasks;
using TaskType = System.Threading.Tasks.Task;


namespace TaskFlow.Application.UseCases.Task
{
    public class DeleteTaskUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async TaskType ExecuteAsync(Guid id) //to figure out name conflict
        {
            throw new NotImplementedException();
        }
    }
}
