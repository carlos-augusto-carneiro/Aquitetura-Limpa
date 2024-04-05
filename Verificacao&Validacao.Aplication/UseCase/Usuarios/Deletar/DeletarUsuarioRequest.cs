using MediatR;

namespace Verificacao_Validacao.Aplication.UseCase.Usuarios.Deletar;

public sealed record DeletarUsuarioRequest(Guid Id) : IRequest<DeletarUsuarioResponse>
{
}
