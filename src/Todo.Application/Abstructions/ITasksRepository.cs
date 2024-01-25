using Todo.Domain.Enums;
using Task = Todo.Domain.Entities.Task;

namespace Todo.Application.Abstructions
{
    public interface ITasksRepository
    {
        ValueTask<Task> AddAsync(Task task, CancellationToken cancellationToken = default);
        ValueTask<Task> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        ValueTask<IEnumerable<Task>> GetAllAsync(CancellationToken cancellationToken = default);
        ValueTask<IEnumerable<Task>> GetByPriorityAsync(PriorityLevel priority, CancellationToken cancellationToken = default);
        ValueTask<IEnumerable<Task>> GetByStateAsync(State state, CancellationToken cancellationToken = default);
        ValueTask<IEnumerable<Task>> GetByDeadlineAsync(DateTime deadline, CancellationToken cancellationToken = default);
        ValueTask<Task> UpdateAsync(Task task, int id, CancellationToken cancellationToken = default);
        ValueTask<Task> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
