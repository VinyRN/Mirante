using Mirante.ToDo.Core.Dto;
using Mirante.ToDo.Core.Entity;
using Mirante.ToDo.Core.Enum;

namespace Mirante.ToDo.Core.Interface.Service
{
    public interface IToDoTaskService
    {
        Task<ServiceResultDto<IEnumerable<ToDoTask>>> GetAllAsync();
        Task<ServiceResultDto<ToDoTask>> GetByIdAsync(int id);
        Task<ServiceResultDto<IEnumerable<ToDoTask>>> GetByFilterAsync(TaskStatusEnum? status, DateTime? dataVencimento);
        Task<ServiceResultDto<int>> CreateAsync(ToDoTask task);
        Task<ServiceResultDto<bool>> UpdateAsync(int id, ToDoTask task);
        Task<ServiceResultDto <bool>> DeleteAsync(int id);
    }
}
