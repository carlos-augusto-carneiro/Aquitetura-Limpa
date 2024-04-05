using FluentValidation;

namespace Verificacao_Validacao.Aplication.UseCase.Usuarios.Atualizar;

public sealed class AtualizarUsuarioValidation : AbstractValidator<AtualizarUsuarioRequest>
{
    public AtualizarUsuarioValidation()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(64).MinimumLength(3);
        RuleFor(x => x.Email).NotEmpty().MaximumLength(128).EmailAddress();
        RuleFor(x => x.Senha).NotEmpty().MaximumLength(24).MinimumLength(8);
    }
}
