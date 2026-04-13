using System.ComponentModel.DataAnnotations;
namespace TaskManagement_API.Models.DTOs
{
    public class TaskCreateDTO
    {
        [Required]
        public required string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public required string Status { get; set; }
        [Required]
        public required string Priority { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
