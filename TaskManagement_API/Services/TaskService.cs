using AutoMapper;
using TaskManagement_API.Entities;
using TaskManagement_API.Repositories;
using TaskManagement_API.IServices;
using TaskManagement_API.Models.DTOs;

namespace TaskManagement_API.Services
{
    public class TaskService : ITaskService
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _repository;

        public TaskService(IMapper mapper, ITaskRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<TaskReadDTO>> GetAllTasksAsync()
        {
            var tasks = await _repository.GetAllAsync();
            return _mapper.Map<List<TaskReadDTO>>(tasks);
        }

        public async Task<TaskReadDTO?> GetTaskByIdAsync(int id)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null) return null;

            return _mapper.Map<TaskReadDTO>(task);
        }

        public async Task<TaskReadDTO> CreateTaskAsync(TaskCreateDTO taskCreateDTO)
        {
            var task = _mapper.Map<TaskItem>(taskCreateDTO);
            task.CreatedAt = DateTime.UtcNow;
            task.UpdatedAt = DateTime.UtcNow;

            await _repository.AddAsync(task);
            await _repository.SaveChangesAsync();

            return _mapper.Map<TaskReadDTO>(task);
        }

        public async Task<TaskReadDTO?> UpdateTaskByIdAsync(int id, TaskUpdateDTO taskUpdateDTO)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null)
            {
                return null;
            }
            _mapper.Map(taskUpdateDTO, task);
            task.UpdatedAt = DateTime.UtcNow;
            await _repository.UpdateAsync(task);
            await _repository.SaveChangesAsync();

            return _mapper.Map<TaskReadDTO>(task);
        }

        public async Task<bool> DeleteTaskByIdAsync(int id)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null) return false;

            await _repository.DeleteAsync(task);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
