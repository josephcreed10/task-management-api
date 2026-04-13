using Microsoft.AspNetCore.Server.HttpSys;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagement_API.Entities
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
        [Required] 
        public required string  Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public required string Status { get; set; }
        [Required]
        public required string Priority { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        
    }
}
