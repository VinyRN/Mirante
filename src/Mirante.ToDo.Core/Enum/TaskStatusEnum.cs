using System.ComponentModel.DataAnnotations;

namespace Mirante.ToDo.Core.Enum
{
    public enum TaskStatusEnum : int
    {
        [Display(Name = "Pendente")]
        Pendente = 0,
        [Display(Name = "Em Andamento")]
        EmAndamento = 1,
        [Display(Name = "Concluído")]
        Concluido = 2
    }
}
