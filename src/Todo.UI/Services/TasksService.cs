using Task = Todo.UI.Models.Task;
namespace Todo.UI.Services
{
    public class TasksService : ITasksService
    {
        private readonly HttpClient _httpClient;
        public TasksService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Task> Tasks { get; set; } = new List<Task>();

        public async ValueTask GetAllTasksAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Task>>("http://localhost:5176/api/Tasks/GetAllTasks");
            Tasks = result;
        }

        public async ValueTask<Task> GetTaskByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Task>($"http://localhost:5176/api/Tasks/GetTaskById/{id}");
        }
    }
}
