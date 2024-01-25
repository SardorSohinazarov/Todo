using Todo.Domain.Common;
using Todo.Domain.Enums;

namespace Todo.Domain.Entities
{
    public class Task : Auditable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public PriorityLevel Priority { get; set; }
        public State State { get; set; }
        public string? Notes { get; set; }
    }
}
