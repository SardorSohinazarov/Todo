using Microsoft.AspNetCore.Mvc;
using Todo.Application.DTOs;
using Todo.Application.Services;
using Todo.Domain.Enums;

namespace Todo.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _taskService;

        public TasksController(ITasksService taskService)
            => _taskService = taskService;

        [HttpPost]
        public async Task<IActionResult> CreateTaskAsync(TaskDTO task, CancellationToken cancellationToken = default)
        {
            var createdTask = await _taskService.CreateTaskAsync(task, cancellationToken);
            return Ok(createdTask);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var task = await _taskService.GetTaskByIdAsync(id, cancellationToken);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasksAsync(CancellationToken cancellationToken = default)
        {
            var tasks = await _taskService.GetAllTasksAsync(cancellationToken);
            return Ok(tasks);
        }

        [HttpGet("{priority}")]
        public async Task<IActionResult> GetTasksByPriorityAsync(PriorityLevel priority, CancellationToken cancellationToken = default)
        {
            var tasks = await _taskService.GetTasksByPriorityAsync(priority, cancellationToken);
            return Ok(tasks);
        }

        [HttpGet("{state}")]
        public async Task<IActionResult> GetTasksByStateAsync(State state, CancellationToken cancellationToken = default)
        {
            var tasks = await _taskService.GetTasksByStateAsync(state, cancellationToken);
            return Ok(tasks);
        }

        [HttpGet("{deadline}")]
        public async Task<IActionResult> GetTasksByDeadlineAsync(DateTime deadline, CancellationToken cancellationToken = default)
        {
            var tasks = await _taskService.GetTasksByDeadlineAsync(deadline, cancellationToken);
            return Ok(tasks);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskAsync(int id, TaskDTO task, CancellationToken cancellationToken = default)
        {
            var updatedTask = await _taskService.UpdateTaskAsync(task, id, cancellationToken);
            if (updatedTask == null)
            {
                return NotFound();
            }
            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskAsync(int id, CancellationToken cancellationToken = default)
        {
            var deletedTask = await _taskService.DeleteTaskAsync(id, cancellationToken);
            if (deletedTask == null)
            {
                return NotFound();
            }
            return Ok(deletedTask);
        }
    }
}
