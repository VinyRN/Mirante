using Microsoft.EntityFrameworkCore;
using Mirante.ToDo.Core.Entity;
using Mirante.ToDo.Core.Enum;
using Mirante.ToDo.Core.Interface.Repository;
using Mirante.ToDo.Data.Context;

namespace Mirante.ToDo.Data.Repository
{
    public class ToDoTaskRepository : IToDoTaskRepository
    {
        private readonly ApplicationDbContext _context;

        public ToDoTaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ToDoTask>> GetAllAsync()
        {
            return await _context.Tasks.AsNoTracking().ToListAsync();
        }

        public async Task<ToDoTask> GetByIdAsync(int id)
        {
            return await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(ToDoTask task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ToDoTask task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var task = await GetByIdAsync(id);
            if (task == null)
                return;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ToDoTask>> GetByFilterAsync(TaskStatusEnum? status,
                                                                  DateTime? dataVencimento)
        {
            IQueryable<ToDoTask> query = _context.Tasks.AsNoTracking();

            if (status.HasValue)
                query = query.Where(x => x.Status == status.Value);

            if (dataVencimento.HasValue)
            {
                var date = dataVencimento.Value.Date;
                var nextDay = date.AddDays(1);

                query = query.Where(x =>
                    x.DataVencimento >= date &&
                    x.DataVencimento < nextDay);
            }

            return await query.ToListAsync();
        }

    }
}
