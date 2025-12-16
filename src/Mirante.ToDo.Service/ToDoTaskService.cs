using FluentValidation;
using Microsoft.Extensions.Logging;
using Mirante.ToDo.Core.Dto;
using Mirante.ToDo.Core.Entity;
using Mirante.ToDo.Core.Enum;
using Mirante.ToDo.Core.Interface.Repository;
using Mirante.ToDo.Core.Interface.Service;

namespace Mirante.ToDo.Service
{
    public class ToDoTaskService : IToDoTaskService
    {
        private readonly ILogger<ToDoTaskService> _logger;
        private readonly IToDoTaskRepository _repository;
        private readonly IValidator<ToDoTask> _validator;

        public ToDoTaskService(
            ILogger<ToDoTaskService> logger,
            IToDoTaskRepository repository,
            IValidator<ToDoTask> validator)
        {
            _logger = logger;
            _repository = repository;
            _validator = validator;
        }

        public async Task<ServiceResultDto<IEnumerable<ToDoTask>>> GetAllAsync()
        {
            var tasks = await _repository.GetAllAsync();
            return ServiceResultDto<IEnumerable<ToDoTask>>.Ok(tasks);
        }

        public async Task<ServiceResultDto<ToDoTask>> GetByIdAsync(int id)
        {
            var task = await _repository.GetByIdAsync(id);

            if (task is null)
                return ServiceResultDto<ToDoTask>.Fail("Tarefa não encontrada");

            return ServiceResultDto<ToDoTask>.Ok(task);
        }

        public async Task<ServiceResultDto<IEnumerable<ToDoTask>>> GetByFilterAsync(
            TaskStatusEnum? status,
            DateTime? dataVencimento)
        {
            var tasks = await _repository.GetByFilterAsync(status, dataVencimento);
            return ServiceResultDto<IEnumerable<ToDoTask>>.Ok(tasks);
        }

        public async Task<ServiceResultDto<int>> CreateAsync(ToDoTask task)
        {
            task.DataInclusao = DateTime.UtcNow;

            var validationResult = await _validator.ValidateAsync(task);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => e.ErrorMessage);

                return ServiceResultDto<int>.Fail(errors);
            }

            await _repository.AddAsync(task);

            return ServiceResultDto<int>.Ok(task.Id);
        }

        public async Task<ServiceResultDto<bool>> UpdateAsync(int id, ToDoTask task)
        {
            var existingTask = await _repository.GetByIdAsync(id);

            if (existingTask is null)
                return ServiceResultDto<bool>.Fail("Tarefa não encontrada");

            existingTask.Titulo = task.Titulo;
            existingTask.Descricao = task.Descricao;
            existingTask.Status = task.Status;
            existingTask.DataVencimento = task.DataVencimento;

            task.DataInclusao = existingTask.DataInclusao;

            var validationResult = await _validator.ValidateAsync(task);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => e.ErrorMessage);

                return ServiceResultDto<bool>.Fail(errors);
            }

            await _repository.UpdateAsync(existingTask);

            return ServiceResultDto<bool>.Ok(true);
        }

        public async Task<ServiceResultDto<bool>> DeleteAsync(int id)
        {
            var existingTask = await _repository.GetByIdAsync(id);

            if (existingTask is null)
                return ServiceResultDto<bool>.Fail("Tarefa não encontrada");

            await _repository.DeleteAsync(id);

            return ServiceResultDto<bool>.Ok(true);
        }
    }
}
