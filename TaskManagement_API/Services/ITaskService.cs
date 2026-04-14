using TaskManagement_API.Models.DTOs;

namespace TaskManagement_API.IServices
{
    public interface ITaskService
    {
        public Task<List<TaskReadDTO>>GetAllTasksAsync();
        public Task<TaskReadDTO?> GetTaskByIdAsync(int id);
        public Task<TaskReadDTO>CreateTaskAsync(TaskCreateDTO taskCreateDTO);
        public Task<TaskReadDTO?> UpdateTaskByIdAsync(int id, TaskUpdateDTO taskUpdateDTO);
        public Task<bool> DeleteTaskByIdAsync(int id);

    }
}
