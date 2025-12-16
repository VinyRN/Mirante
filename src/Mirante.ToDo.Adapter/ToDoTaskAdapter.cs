using AutoMapper;
using Azure.Core;
using Microsoft.Extensions.Logging;
using Mirante.ToDo.Core.Dto;
using Mirante.ToDo.Core.Dto.Request;
using Mirante.ToDo.Core.Dto.Response;
using Mirante.ToDo.Core.Entity;
using Mirante.ToDo.Core.Enum;
using Mirante.ToDo.Core.Interface.Adapter;
using Mirante.ToDo.Core.Interface.Service;

namespace Mirante.ToDo.Adapter
{
    public class ToDoTaskAdapter : IToDoTaskAdapter
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ToDoTaskAdapter> _logger;
        private readonly IToDoTaskService _toDoTaskService;

        public ToDoTaskAdapter(ILogger<ToDoTaskAdapter> logger,
                               IMapper mapper, 
                               IToDoTaskService toDoTaskService)
        {
            _logger = logger;
            _toDoTaskService = toDoTaskService;
            _mapper = mapper;
        }

        public async Task<ReturnResponseDto> GetAllAsync()
        {
            _logger.LogInformation("Buscando todas as tarefas");

            ReturnResponseDto returnResponseDto = new ReturnResponseDto();
            returnResponseDto.Erros = new List<ReturnResponseErrorDto>();

            try
            {
                var result = await _toDoTaskService.GetAllAsync();

                if (result != null)
                {
                    if (result.Success == true)
                    {
                        if (result.Data != null && result.Data.Count() > 0)
                        {
                            var dto = _mapper.Map<List<ToDoTaskResponseDto>>(result.Data);

                            returnResponseDto.Error = false;
                            returnResponseDto.StatusCode = 200;
                            returnResponseDto.Data = dto;
                            returnResponseDto.Erros = null;
                        }
                        else
                        {
                            returnResponseDto.Error = false;
                            returnResponseDto.StatusCode = 404;
                            returnResponseDto.Data = null;
                        }
                    }
                    else
                    {
                        returnResponseDto.Error = false;
                        returnResponseDto.StatusCode = 400;
                        returnResponseDto.Data = null;
                        returnResponseDto.Erros = new List<ReturnResponseErrorDto>();
                        result.Errors.ToList().ForEach(err =>
                        {
                            returnResponseDto.Erros.Add(new ReturnResponseErrorDto { ErrorMessage = err });
                        });
                    }
                }
                else
                {
                    returnResponseDto.Error = false;
                    returnResponseDto.StatusCode = 404;
                    returnResponseDto.Data = null;
                }
            }
            catch (Exception ex)
            {

                returnResponseDto.Error = true;
                returnResponseDto.StatusCode = 500;
                returnResponseDto.Data = null;
                returnResponseDto.Erros?.Add(new ReturnResponseErrorDto()
                {
                    ErrorCode = 500,
                    ErrorMessage = ex.Message
                });
            }

            return returnResponseDto;
        }
        public async Task<ReturnResponseDto> GetByIdAsync(int id)
        {
            _logger.LogInformation("Buscando tarefa pelo Id {Id}", id);

            ReturnResponseDto returnResponseDto = new ReturnResponseDto();
            returnResponseDto.Erros = new List<ReturnResponseErrorDto>();

            try
            {
                var result = await _toDoTaskService.GetByIdAsync(id);

                if (result != null)
                {
                    if (result.Success == true)
                    {
                        if (result.Data != null)
                        {
                            var dto = _mapper.Map<ToDoTaskResponseDto>(result.Data);

                            returnResponseDto.Error = false;
                            returnResponseDto.StatusCode = 200;
                            returnResponseDto.Data = dto;
                            returnResponseDto.Erros = null;
                        }
                        else
                        {
                            returnResponseDto.Error = false;
                            returnResponseDto.StatusCode = 404;
                            returnResponseDto.Data = null;
                        }
                    }
                    else
                    {
                        returnResponseDto.Error = false;
                        returnResponseDto.StatusCode = 400;
                        returnResponseDto.Data = null;
                        returnResponseDto.Erros = new List<ReturnResponseErrorDto>();
                        result.Errors.ToList().ForEach(err =>
                        {
                            returnResponseDto.Erros.Add(new ReturnResponseErrorDto { ErrorMessage = err });
                        });
                    }
                }
                else
                {
                    returnResponseDto.Error = false;
                    returnResponseDto.StatusCode = 404;
                    returnResponseDto.Data = null;
                }
            }
            catch (Exception ex)
            {

                returnResponseDto.Error = true;
                returnResponseDto.StatusCode = 500;
                returnResponseDto.Data = null;
                returnResponseDto.Erros?.Add(new ReturnResponseErrorDto()
                {
                    ErrorCode = 500,
                    ErrorMessage = ex.Message
                });
            }

            return returnResponseDto;

        }
        public async Task<ReturnResponseDto> GetByFilterAsync(TaskStatusEnum? status, DateTime? dataVencimento)
        {
            _logger.LogInformation("Filtrando tarefas. Status: {Status}, DataVencimento: {DataVencimento}", status, dataVencimento);

            ReturnResponseDto returnResponseDto = new ReturnResponseDto();
            returnResponseDto.Erros = new List<ReturnResponseErrorDto>();

            try
            {
                var result = await _toDoTaskService.GetByFilterAsync(status, dataVencimento);

                if (result != null)
                {
                    if (result.Success == true)
                    {
                        if (result.Data != null)
                        {
                            var dto = _mapper.Map<List<ToDoTaskResponseDto>>(result.Data);

                            returnResponseDto.Error = false;
                            returnResponseDto.StatusCode = 200;
                            returnResponseDto.Data = dto;
                            returnResponseDto.Erros = null;
                        }
                        else
                        {
                            returnResponseDto.Error = false;
                            returnResponseDto.StatusCode = 404;
                            returnResponseDto.Data = null;
                        }
                    }
                    else
                    {
                        returnResponseDto.Error = false;
                        returnResponseDto.StatusCode = 400;
                        returnResponseDto.Data = null;
                        returnResponseDto.Erros = new List<ReturnResponseErrorDto>();
                        result.Errors.ToList().ForEach(err =>
                        {
                            returnResponseDto.Erros.Add(new ReturnResponseErrorDto { ErrorMessage = err });
                        });
                    }
                }
                else
                {
                    returnResponseDto.Error = false;
                    returnResponseDto.StatusCode = 404;
                    returnResponseDto.Data = null;
                }
            }
            catch (Exception ex)
            {

                returnResponseDto.Error = true;
                returnResponseDto.StatusCode = 500;
                returnResponseDto.Data = null;
                returnResponseDto.Erros?.Add(new ReturnResponseErrorDto()
                {
                    ErrorCode = 500,
                    ErrorMessage = ex.Message
                });
            }

            return returnResponseDto;

        }
        public async Task<ReturnResponseDto> CreateAsync(ToDoTaskRequestDto request)
        {
            _logger.LogInformation("Criando nova tarefa");

            ReturnResponseDto returnResponseDto = new ReturnResponseDto();
            returnResponseDto.Erros = new List<ReturnResponseErrorDto>();

            try
            {
                var task = _mapper.Map<ToDoTask>(request);

                var result = await _toDoTaskService.CreateAsync(task);

                if (result != null)
                {
                    if (result.Success == true)
                    {
                        if (result.Data != 0)
                        {
                            ///var dto = _mapper.Map<List<ToDoTaskResponseDto>>(result.Data);

                            returnResponseDto.Error = false;
                            returnResponseDto.StatusCode = 200;
                            returnResponseDto.Data = result.Data;
                            returnResponseDto.Erros = null;
                        }
                        else
                        {
                            returnResponseDto.Error = false;
                            returnResponseDto.StatusCode = 404;
                            returnResponseDto.Data = null;
                        }
                    }
                    else
                    {
                        returnResponseDto.Error = false;
                        returnResponseDto.StatusCode = 400;
                        returnResponseDto.Data = result.Data;
                        returnResponseDto.Erros = new List<ReturnResponseErrorDto>();
                        result.Errors.ToList().ForEach(err =>
                        {
                            returnResponseDto.Erros.Add(new ReturnResponseErrorDto { ErrorMessage = err });
                        });
                    }
                }
                else
                {
                    returnResponseDto.Error = false;
                    returnResponseDto.StatusCode = 404;
                    returnResponseDto.Data = null;
                }
                
            }
            catch (Exception ex)
            {

                returnResponseDto.Error = true;
                returnResponseDto.StatusCode = 500;
                returnResponseDto.Data = null;
                returnResponseDto.Erros?.Add(new ReturnResponseErrorDto()
                {
                    ErrorCode = 500,
                    ErrorMessage = ex.Message
                });
            }

            return returnResponseDto;
        }
        public async Task<ReturnResponseDto> UpdateAsync(int id, ToDoTaskRequestDto request)
        {
            _logger.LogInformation("Atualizando tarefa Id {Id}", id);

            ReturnResponseDto returnResponseDto = new ReturnResponseDto();
            returnResponseDto.Erros = new List<ReturnResponseErrorDto>();

            try
            {
                var task = _mapper.Map<ToDoTask>(request);

                var result = await _toDoTaskService.UpdateAsync(id, task);

                if (result != null)
                {
                    if (result.Success == true)
                    {
                        if (result.Data == true)    
                        {
                            returnResponseDto.Error = false;
                            returnResponseDto.StatusCode = 200;
                            returnResponseDto.Data = result.Data;
                            returnResponseDto.Erros = null;
                        }
                        else
                        {
                            returnResponseDto.Error = false;
                            returnResponseDto.StatusCode = 404;
                            returnResponseDto.Data = null;
                        }
                    }
                    else
                    {
                        returnResponseDto.Error = false;
                        returnResponseDto.StatusCode = 400;
                        returnResponseDto.Data = result.Data;
                        returnResponseDto.Erros = new List<ReturnResponseErrorDto>();
                        result.Errors.ToList().ForEach(err =>
                        {
                            returnResponseDto.Erros.Add(new ReturnResponseErrorDto { ErrorMessage = err });
                        });
                    }
                }
                else
                {
                    returnResponseDto.Error = false;
                    returnResponseDto.StatusCode = 404;
                    returnResponseDto.Data = null;
                }

            }
            catch (Exception ex)
            {

                returnResponseDto.Error = true;
                returnResponseDto.StatusCode = 500;
                returnResponseDto.Data = null;
                returnResponseDto.Erros?.Add(new ReturnResponseErrorDto()
                {
                    ErrorCode = 500,
                    ErrorMessage = ex.Message
                });
            }

            return returnResponseDto;

        }
        public async Task<ReturnResponseDto> DeleteAsync(int id)
        {
            _logger.LogInformation("Removendo tarefa Id {Id}", id);

            ReturnResponseDto returnResponseDto = new ReturnResponseDto();
            returnResponseDto.Erros = new List<ReturnResponseErrorDto>();

            try
            {
                var result = await _toDoTaskService.DeleteAsync(id);

                if (result != null)
                {
                    if (result.Success == true)
                    {
                        if (result.Data == true)
                        {
                            returnResponseDto.Error = false;
                            returnResponseDto.StatusCode = 200;
                            returnResponseDto.Data = result.Data;
                            returnResponseDto.Erros = null;
                        }
                        else
                        {
                            returnResponseDto.Error = false;
                            returnResponseDto.StatusCode = 404;
                            returnResponseDto.Data = null;
                        }
                    }
                    else
                    {
                        returnResponseDto.Error = false;
                        returnResponseDto.StatusCode = 400;
                        returnResponseDto.Data = result.Data;
                        returnResponseDto.Erros = new List<ReturnResponseErrorDto>();
                        result.Errors.ToList().ForEach(err =>
                        {
                            returnResponseDto.Erros.Add(new ReturnResponseErrorDto { ErrorMessage = err });
                        });
                    }
                }
                else
                {
                    returnResponseDto.Error = false;
                    returnResponseDto.StatusCode = 404;
                    returnResponseDto.Data = null;
                }

            }
            catch (Exception ex)
            {

                returnResponseDto.Error = true;
                returnResponseDto.StatusCode = 500;
                returnResponseDto.Data = null;
                returnResponseDto.Erros?.Add(new ReturnResponseErrorDto()
                {
                    ErrorCode = 500,
                    ErrorMessage = ex.Message
                });
            }

            return returnResponseDto;

        }
    }
}
