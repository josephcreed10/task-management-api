using TaskManagement_API.Custom_Validation;
using TaskManagement_API.Enums;

namespace TaskManagement_API.Models.DTOs
{
    public class TaskUpdateDTO
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        [EnumValidation(typeof(Enums.TaskStatus))]
        public required Enums.TaskStatus Status { get; set; }
        [EnumValidation(typeof(TaskPriority))]
        public required TaskPriority Priority { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
