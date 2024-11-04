using Microsoft.EntityFrameworkCore;
using ToDoTask.DataBases.Entitys;

namespace ToDoTask.DataBases.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationSQLliteContext _context;

        public TaskRepository(ApplicationSQLliteContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TaskEntity entity)
        {
            _context.Tasks.Attach(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(IEnumerable<TaskEntity> entities)
        {
            _context.Tasks.AttachRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Action<TaskEntity> updatedEntity)
        {
            var taskEntity = await _context.Tasks.FindAsync(id) ?? throw new KeyNotFoundException($"Task with ID {id} not found.");

            updatedEntity(taskEntity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var taskEntity = await _context.Tasks.FindAsync(id) ?? throw new KeyNotFoundException($"Task with ID {id} not found.");

            _context.Tasks.Remove(taskEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<TaskEntity?> GetByIdAsync(int id)
        {
            return await _context.Tasks
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TaskEntity?> GetByTitleAsync(string title)
        {
            return await _context.Tasks
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Title == title); ;
        }

        public async Task<IEnumerable<TaskEntity>?> GetAllAsync()
        {
            var tasks = await _context.Tasks
                    .AsNoTracking()
                    .ToListAsync();

            return tasks!;
        }

        public async Task<IEnumerable<TaskEntity>> GetCompletedAsync(bool completed)
        {
            return await _context.Tasks
                .AsNoTracking()
                .Where(t => t.Completed == completed)
                .ToListAsync();
        }

        public async Task<IEnumerable<TaskEntity>> GetByGroupIdAsync(int groupId)
        {
            return await _context.Tasks
                .AsNoTracking()
                .Where(t => t.GroupEntityId == groupId)
                .ToListAsync();
        }

        public async Task<IEnumerable<TaskEntity>> GetByDeadlineAsync(DateTime start, DateTime end)
        {
            return await _context.Tasks
                .AsNoTracking()
                .Where(t => t.Deadline >= start && t.Deadline < end)
                .ToListAsync();
        }
    }
}