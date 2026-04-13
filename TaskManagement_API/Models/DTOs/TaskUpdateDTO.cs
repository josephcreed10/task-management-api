namespace TaskManagement_API.Models.DTOs
{
    public class TaskUpdateDTO
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required string Status { get; set; }
        public required string Priority { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
