using Mirante.ToDo.Core.Entity;
using Mirante.ToDo.Core.Enum;

namespace Mirante.ToDo.Core.Interface.Repository
{
    public interface IToDoTaskRepository
    {
        Task<IEnumerable<ToDoTask>> GetAllAsync();
        Task<ToDoTask> GetByIdAsync(int id);
        Task AddAsync(ToDoTask task);
        Task UpdateAsync(ToDoTask task);
        Task DeleteAsync(int id);
        Task<IEnumerable<ToDoTask>> GetByFilterAsync(TaskStatusEnum? status, DateTime? dataVencimento);
    }
}
