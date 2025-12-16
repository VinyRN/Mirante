using FluentValidation;
using Mirante.ToDo.Core.Entity;

namespace Mirante.ToDo.Core.Validation
{
    public class ToDoTaskValidation : AbstractValidator<ToDoTask>
    {
        public ToDoTaskValidation()
        {
            RuleFor(x => x.Titulo)
            .NotEmpty().WithMessage("O título é obrigatório")
            .MaximumLength(255).WithMessage("O título deve ter no máximo 255 caracteres");

            RuleFor(x => x.Descricao)
                .MaximumLength(400).WithMessage("A descrição deve ter no máximo 400 caracteres");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Status inválido");

            RuleFor(x => x.DataVencimento)
                .NotEmpty().WithMessage("A data de vencimento é obrigatória")
                .GreaterThan(DateTime.Today.AddDays(-1))
                .WithMessage("A data de vencimento não pode ser anterior à data atual");

            RuleFor(x => x.DataInclusao)
                .NotEmpty().WithMessage("A data de inclusão é obrigatória");
        }
    }
}
