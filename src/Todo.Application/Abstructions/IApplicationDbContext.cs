using Microsoft.EntityFrameworkCore;
using Task = Todo.Domain.Entities.Task;

namespace Todo.Infrastructure.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Task> Tasks { get; set; }

        ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
