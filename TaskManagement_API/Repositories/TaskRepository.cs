using TaskManagement_API.Entities;
using Microsoft.EntityFrameworkCore;
namespace TaskManagement_API.Repositories
{
    public class TaskRepository: ITaskRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public TaskRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(TaskItem task)
        {
            await _dbContext.Tasks.AddAsync(task);
        }

        public void Update(TaskItem task)
        {
            _dbContext.Tasks.Update(task);
        }

        public void Delete(TaskItem task)
        {
            _dbContext.Tasks.Remove(task);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
