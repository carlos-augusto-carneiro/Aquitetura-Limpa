using FluentValidation;

namespace Verificacao_Validacao.Aplication.UseCase.Usuarios.Adicionar;

public sealed class AdicionarUsuarioValidation : AbstractValidator<AdicionarUsuarioRequest>
{
    public AdicionarUsuarioValidation()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(64).MinimumLength(3);
        RuleFor(x => x.Email).NotEmpty().MaximumLength(128).EmailAddress();
        RuleFor(x => x.Senha).NotEmpty().MaximumLength(24).MinimumLength(8);
        RuleFor(x => x.DatadeCriacao).NotEmpty().LessThan(x => DateTime.Now);
    }
}
