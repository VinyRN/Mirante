using Microsoft.AspNetCore.Mvc;
using Mirante.ToDo.Core.Dto.Request;
using Mirante.ToDo.Core.Enum;
using Mirante.ToDo.Core.Interface.Adapter;


namespace Mirante.ToDo.API.Controllers
{
    [ApiController]
    [Route("api/todo-tasks")]
    public class ToDoTaskController : ControllerBase
    {
        private readonly IToDoTaskAdapter _toDoTaskAdapter;

        public ToDoTaskController(IToDoTaskAdapter toDoTaskAdapter)
        {
            _toDoTaskAdapter = toDoTaskAdapter;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _toDoTaskAdapter.GetAllAsync();

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _toDoTaskAdapter.GetByIdAsync(id);

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("filtrar")]
        public async Task<IActionResult> Filtrar(
            [FromQuery] TaskStatusEnum? status,
            [FromQuery] DateTime? dataVencimento)
        {
            var result = await _toDoTaskAdapter
                .GetByFilterAsync(status, dataVencimento);

            if (result.StatusCode == StatusCodes.Status200OK)
            {
                return Ok(result);
            }
            else if (result.StatusCode == StatusCodes.Status404NotFound)
            {
                return NotFound("Nenhuma tarefa encontrada");
            }
            else
            {
                return StatusCode(result.StatusCode, result.Erros);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ToDoTaskRequestDto task)
        {
            var result = await _toDoTaskAdapter.CreateAsync(task);
            
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ToDoTaskRequestDto task)
        {
            var result = await _toDoTaskAdapter.UpdateAsync(id, task);

            return StatusCode(result.StatusCode, result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _toDoTaskAdapter.DeleteAsync(id);

            return StatusCode(result.StatusCode, result);
        }
    }
}
