using Microsoft.EntityFrameworkCore;
using Todo.Application.Abstructions;
using Todo.Domain.Enums;
using Todo.Domain.Exceptions;
using Todo.Infrastructure.Data;
using Task = Todo.Domain.Entities.Task;

namespace Todo.Infrastructure.Repositories
{
    public class TaskRepository : ITasksRepository
    {
        private readonly IApplicationDbContext _dbContext;

        public TaskRepository(IApplicationDbContext dbContext)
            => _dbContext = dbContext;

        public async ValueTask<Task> AddAsync(Task task, CancellationToken cancellationToken = default)
        {
            var entry = await _dbContext.Tasks.AddAsync(task, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entry.Entity;
        }

        public async ValueTask<Task> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async ValueTask<IEnumerable<Task>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _dbContext.Tasks.ToListAsync(cancellationToken);

        public async ValueTask<IEnumerable<Task>> GetByPriorityAsync(PriorityLevel priority, CancellationToken cancellationToken = default)
            => await _dbContext.Tasks.Where(task => task.Priority == priority).ToListAsync(cancellationToken);

        public async ValueTask<IEnumerable<Task>> GetByStateAsync(State state, CancellationToken cancellationToken = default)
            => await _dbContext.Tasks.Where(task => task.State == state).ToListAsync(cancellationToken);

        public async ValueTask<IEnumerable<Task>> GetByDeadlineAsync(DateTime deadline, CancellationToken cancellationToken = default)
            => await _dbContext.Tasks.Where(task => task.Deadline == deadline).ToListAsync(cancellationToken);

        public async ValueTask<Task> UpdateAsync(Task task, int id, CancellationToken cancellationToken = default)
        {
            var existingTask = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (existingTask != null)
            {
                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.Deadline = task.Deadline;
                existingTask.Priority = task.Priority;
                existingTask.State = task.State;
                existingTask.Notes = task.Notes;

                var entry = _dbContext.Tasks.Update(existingTask);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return entry.Entity;
            }

            throw new TaskNotFoundException(id);
        }

        public async ValueTask<Task> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var existingTask = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (existingTask != null)
            {
                var entry = _dbContext.Tasks.Remove(existingTask);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return entry.Entity;
            }

            throw new TaskNotFoundException(id);
        }
    }
}
