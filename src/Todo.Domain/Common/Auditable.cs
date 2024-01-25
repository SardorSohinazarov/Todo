namespace Todo.Domain.Common
{
    public abstract class Auditable : BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
    }
}
