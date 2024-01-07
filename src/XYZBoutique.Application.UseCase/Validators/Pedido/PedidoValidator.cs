using FluentValidation;
using XYZBoutique.Application.UseCase.UseCases.Pedidos.Commands.CreateCommand;
/// <summary>
/// Validador para el comando de creación de pedidos.
/// </summary>
public class PedidoValidator : AbstractValidator<CreatePedidoCommand>
{
    public PedidoValidator()
    {
        RuleFor(x => x.IdUsuarioSolicitante)
            .NotNull().WithMessage("El id del usuario solicitante no puede ser nulo.")
            .NotEmpty().WithMessage("El id del usuario solicitante no puede ser vacío.");

        RuleFor(x => x.Repartidor)
            .NotNull().WithMessage("El repartidor no puede ser nulo.")
            .NotEmpty().WithMessage("El repartidor no puede ser vacío.");

        RuleFor(x => x.Repartidor)
            .NotNull().WithMessage("El repartidor no puede ser nulo.")
            .NotEmpty().WithMessage("El repartidor no puede ser vacío.");
    }
}
