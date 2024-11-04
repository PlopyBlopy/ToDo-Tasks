using Microsoft.EntityFrameworkCore;
using ToDoTask.DataBases.Entitys;

namespace ToDoTask.DataBases.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationSQLliteContext _context;

        public GroupRepository(ApplicationSQLliteContext context)
        {
            _context = context;
        }

        public async Task AddAsync(GroupEntity entity)
        {
            _context.Groups.Attach(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(IEnumerable<GroupEntity> entities)
        {
            _context.Groups.AttachRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Action<GroupEntity> updatedEntity)
        {
            var groupEntity = await _context.Groups.FindAsync(id) ?? throw new KeyNotFoundException($"Task with ID {id} not found.");

            updatedEntity(groupEntity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var groupEntity = await _context.Groups.FindAsync(id) ?? throw new KeyNotFoundException($"Task with ID {id} not found.");

            _context.Groups.Remove(groupEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<GroupEntity?> GetByIdAsync(int id)
        {
            return await _context.Groups
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<GroupEntity?> GetByTitleAsync(string title)
        {
            return await _context.Groups
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.Title == title);
        }

        public async Task<IEnumerable<GroupEntity>?> GetAllAsync()
        {
            var groups = await _context.Groups
                    .AsNoTracking()
                    .ToListAsync();

            return groups!;
        }

        public async Task<IEnumerable<TaskEntity>> GetTasksByGroupIdAsync(int groupId)
        {
            var groupEntity = await _context.Groups
                    .AsNoTracking()
                    .Include(g => g.Tasks)
                    .FirstOrDefaultAsync(g => g.Id == groupId) ?? throw new KeyNotFoundException($"Group with ID {groupId} not found.");

            return groupEntity.Tasks!;
        }

        public async Task<IEnumerable<TaskEntity>> GetTasksByGroupTitleAsync(string groupTitle)
        {
            var groupEntity = await _context.Groups
                    .AsNoTracking()
                    .Include(g => g.Tasks)
                    .FirstOrDefaultAsync(g => g.Title == groupTitle) ?? throw new KeyNotFoundException($"Group with Title {groupTitle} not found.");

            return groupEntity.Tasks!;
        }
    }
}