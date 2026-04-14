using System.ComponentModel.DataAnnotations;
using TaskManagement_API.Enums;
namespace TaskManagement_API.Entities
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
        [Required] 
        public required string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public required Enums.TaskItemStatus Status { get; set; }
        [Required]
        public required TaskItemPriority Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
    }
}
