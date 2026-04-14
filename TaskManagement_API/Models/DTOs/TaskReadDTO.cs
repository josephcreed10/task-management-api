using TaskManagement_API.Enums;

namespace TaskManagement_API.Models.DTOs
{
    public class TaskReadDTO
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required Enums.TaskStatus Status { get; set; }
        public required TaskPriority Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
