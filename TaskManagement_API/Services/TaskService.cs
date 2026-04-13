using AutoMapper;
using TaskManagement_API.Entities;
using TaskManagement_API.IServices;
using TaskManagement_API.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace TaskManagement_API.Services
{
    public class TaskService: ITaskService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;
        public TaskService(IMapper mapper, ApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<List<TaskReadDTO>> GetAllTasksAsync()
        {
            var tasks = await _dbContext.Tasks.ToListAsync();
            return _mapper.Map<List<TaskReadDTO>>(tasks);
        }
        public async Task<TaskReadDTO?> GetTaskByIdAsync(int id)
        {
            var task = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<TaskReadDTO>(task);
        }
        public async Task<TaskReadDTO> CreateTaskAsync(TaskCreateDTO taskCreateDTO)
        {
            var task = _mapper.Map<TaskItem>(taskCreateDTO);
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<TaskReadDTO>(task);
        }
        public async Task<TaskReadDTO?> UpdateTaskByIdAsync(int id, TaskUpdateDTO taskUpdateDTO)
        {
            var task = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            _mapper.Map(taskUpdateDTO, task);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<TaskReadDTO>(task);
        }
        public async Task<bool> DeleteTaskByIdAsync(int id)
        {
            var task = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (task == null)
            {
                return false;
            }
            _dbContext.Tasks.Remove(task);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
