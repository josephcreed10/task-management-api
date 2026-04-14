using TaskManagement_API.Custom_Validation;
using TaskManagement_API.Enums;

namespace TaskManagement_API.Models.DTOs
{
    public class TaskUpdateDTO
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        [EnumValidation(typeof(TaskStatusEnum))]
        public required TaskStatusEnum Status { get; set; }
        [EnumValidation(typeof(TaskPriorityEnum))]
        public required TaskPriorityEnum Priority { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
