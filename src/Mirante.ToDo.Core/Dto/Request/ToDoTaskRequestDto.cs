using Mirante.ToDo.Core.Enum;

namespace Mirante.ToDo.Core.Dto.Request
{
    public class ToDoTaskRequestDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public TaskStatusEnum Status { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
