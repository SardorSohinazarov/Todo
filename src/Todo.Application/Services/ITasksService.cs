using Todo.Application.DTOs;
using Todo.Domain.Enums;
using Task = Todo.Domain.Entities.Task;

namespace Todo.Application.Services
{
    public interface ITasksService
    {
        ValueTask<Task> CreateTaskAsync(TaskDTO task, CancellationToken cancellationToken = default);
        ValueTask<Task> GetTaskByIdAsync(int id, CancellationToken cancellationToken = default);
        ValueTask<IEnumerable<Task>> GetAllTasksAsync(CancellationToken cancellationToken = default);
        ValueTask<IEnumerable<Task>> GetTasksByPriorityAsync(PriorityLevel priority, CancellationToken cancellationToken = default);
        ValueTask<IEnumerable<Task>> GetTasksByStateAsync(State state, CancellationToken cancellationToken = default);
        ValueTask<IEnumerable<Task>> GetTasksByDeadlineAsync(DateTime deadline, CancellationToken cancellationToken = default);
        ValueTask<Task> UpdateTaskAsync(TaskDTO task, int id, CancellationToken cancellationToken = default);
        ValueTask<Task> DeleteTaskAsync(int id, CancellationToken cancellationToken = default);
    }
}
