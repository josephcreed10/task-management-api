using TaskManagement_API.CustomValidation;
using TaskManagement_API.Enums;

namespace TaskManagement_API.Models.DTOs
{
    public class TaskUpdateDTO
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        [EnumValidation(typeof(TaskItemStatus))]
        public required TaskItemStatus Status { get; set; }
        [EnumValidation(typeof(TaskItemPriority))]
        public required TaskItemPriority Priority { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
