using Todo.Domain.Enums;

namespace Todo.Application.DTOs
{
    public class TaskDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public PriorityLevel Priority { get; set; }
        public State State { get; set; }
        public string? Notes { get; set; }
    }
}
