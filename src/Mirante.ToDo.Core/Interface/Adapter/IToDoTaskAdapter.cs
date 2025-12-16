using Mirante.ToDo.Core.Dto;
using Mirante.ToDo.Core.Dto.Request;
using Mirante.ToDo.Core.Enum;

namespace Mirante.ToDo.Core.Interface.Adapter
{
    public interface IToDoTaskAdapter
    {
        Task<ReturnResponseDto> GetAllAsync();
        Task<ReturnResponseDto> GetByIdAsync(int id);
        Task<ReturnResponseDto> GetByFilterAsync(TaskStatusEnum? status, DateTime? dataVencimento);
        Task<ReturnResponseDto> CreateAsync(ToDoTaskRequestDto task);
        Task<ReturnResponseDto> UpdateAsync(int id, ToDoTaskRequestDto task);
        Task<ReturnResponseDto> DeleteAsync(int id);
    }
}
