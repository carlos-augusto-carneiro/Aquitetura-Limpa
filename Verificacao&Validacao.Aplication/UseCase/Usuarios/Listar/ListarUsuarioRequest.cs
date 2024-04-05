using MediatR;

namespace Verificacao_Validacao.Aplication.UseCase.Usuarios.Listar;

public sealed record ListarUsuarioRequest : IRequest<List<ListarUsuarioResponse>>
{
}
