using Todo.Application.Abstructions;
using Todo.Domain.Enums;
using Todo.Domain.Exceptions;
using Task = Todo.Domain.Entities.Task;

namespace Todo.Application.Services
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _tasksRepository;

        public TasksService(ITasksRepository tasksRepository)
            => _tasksRepository = tasksRepository;

        public async ValueTask<Task> CreateTaskAsync(Task task, CancellationToken cancellationToken = default)
            => await _tasksRepository.AddAsync(task, cancellationToken);

        public async ValueTask<Task> DeleteTaskAsync(int id, CancellationToken cancellationToken = default)
        {
            var existingTask = await _tasksRepository.GetByIdAsync(id, cancellationToken);

            if (existingTask != null)
                return await _tasksRepository.DeleteAsync(id, cancellationToken);

            throw new TaskNotFoundException(id);
        }

        public async ValueTask<IEnumerable<Task>> GetAllTasksAsync(CancellationToken cancellationToken = default)
            => await _tasksRepository.GetAllAsync(cancellationToken);

        public async ValueTask<Task> GetTaskByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var existingTask = await _tasksRepository.GetByIdAsync(id, cancellationToken);

            if (existingTask != null)
                return existingTask;

            throw new TaskNotFoundException(id);
        }

        public async ValueTask<IEnumerable<Task>> GetTasksByDeadlineAsync(DateTime deadline, CancellationToken cancellationToken = default)
            => await _tasksRepository.GetByDeadlineAsync(deadline, cancellationToken);

        public async ValueTask<IEnumerable<Task>> GetTasksByPriorityAsync(PriorityLevel priority, CancellationToken cancellationToken = default)
            => await _tasksRepository.GetByPriorityAsync(priority, cancellationToken);

        public async ValueTask<IEnumerable<Task>> GetTasksByStateAsync(State state, CancellationToken cancellationToken = default)
            => await _tasksRepository.GetByStateAsync(state, cancellationToken);

        public async ValueTask<Task> UpdateTaskAsync(Task task, int id, CancellationToken cancellationToken = default)
        {
            var existingTask = await _tasksRepository.GetByIdAsync(id, cancellationToken);
            if (existingTask != null)
            {
                task.Id = existingTask.Id;
                return await _tasksRepository.UpdateAsync(task, id, cancellationToken);
            }

            throw new TaskNotFoundException(id);
        }
    }
}
