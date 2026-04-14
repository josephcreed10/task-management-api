using System.ComponentModel.DataAnnotations;
using TaskManagement_API.Enums; 
namespace TaskManagement_API.Models.DTOs
{
    public class TaskCreateDTO
    {
        [Required]
        public required string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public required TaskStatusEnum Status { get; set; }
        [Required]
        public required TaskPriorityEnum Priority { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
