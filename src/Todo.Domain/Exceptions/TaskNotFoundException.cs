namespace Todo.Domain.Exceptions
{
    public class TaskNotFoundException : Exception
    {
        public TaskNotFoundException(int id)
            : base(message: $"Task with ID {id} not found.")
        {
        }
    }
}
