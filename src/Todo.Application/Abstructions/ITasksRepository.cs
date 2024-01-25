using Todo.Domain.Enums;
using Task = Todo.Domain.Entities.Task;

namespace Todo.Application.Abstructions
{
    public interface ITasksRepository
    {
        ValueTask<Task> AddAsync(Task task);
        ValueTask<Task> GetByIdAsync(int id);
        ValueTask<IEnumerable<Task>> GetAllAsync();
        ValueTask<IEnumerable<Task>> GetByPriorityAsync(PriorityLevel priority);
        ValueTask<IEnumerable<Task>> GetByStateAsync(State state);
        ValueTask<IEnumerable<Task>> GetByDeadlineAsync(DateTime deadline);
        ValueTask<Task> UpdateAsync(Task task, int id);
        ValueTask<Task> DeleteAsync(int id);
    }
}
