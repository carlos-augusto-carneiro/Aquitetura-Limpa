
using MediatR;

namespace Verificacao_Validacao.Aplication.UseCase.Usuarios.Atualizar;

public sealed record AtualizarUsuarioRequest(Guid Id,string Name, string Email, string Senha) : IRequest<AtualizarUsuarioResponse>
{
}
