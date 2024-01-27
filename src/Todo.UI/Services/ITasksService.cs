using Task = Todo.UI.Models.Task;

namespace Todo.UI.Services
{
    public interface ITasksService
    {
        public List<Task> Tasks { get; set; }
        public ValueTask GetAllTasksAsync();
        public ValueTask<Task> GetTaskByIdAsync(int id);
    }
}
