using MediatR;

namespace Verificacao_Validacao.Aplication.UseCase.Usuarios.Adicionar;

public sealed record AdicionarUsuarioRequest(string Name, string Email, string Senha, DateTime DatadeCriacao) : IRequest<AdicionarUsuarioResponse>
{
}
