using Microsoft.AspNetCore.Components;
using Task = Todo.UI.Models.Task;
namespace Todo.UI.Services
{
    public class TasksService : ITasksService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public TasksService(
            HttpClient httpClient,
            NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public List<Task> Tasks { get; set; } = new List<Task>();

        public async ValueTask CreateTask(Task task)
        {
            var result = await _httpClient.PostAsJsonAsync("http://localhost:5176/api/Tasks/CreateTask", task);
            _navigationManager.NavigateTo("/tasks");
        }

        public async ValueTask DeleteTaskByIdAsync(int id)
        {
            await _httpClient.DeleteAsync($"http://localhost:5176/api/Tasks/DeleteTask/{id}");
            _navigationManager.NavigateTo("/tasks", forceLoad: true);
        }

        public async ValueTask GetAllTasksAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Task>>("http://localhost:5176/api/Tasks/GetAllTasks");
            Tasks = result;
        }

        public async ValueTask<Task> GetTaskByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Task>($"http://localhost:5176/api/Tasks/GetTaskById/{id}");
        }

        public async ValueTask UpdateTaskByIdAsync(Task task)
        {
            await _httpClient.PutAsJsonAsync($"http://localhost:5176/api/Tasks/UpdateTask/{task.Id}", task);
            _navigationManager.NavigateTo("/tasks", forceLoad: true);
        }
    }
}
