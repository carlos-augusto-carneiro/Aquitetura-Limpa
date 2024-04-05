

namespace Verificacao_Validacao.Aplication.UseCase.Usuarios.Adicionar;

public sealed record AdicionarUsuarioResponse
{
    public string Name { get; set; } = default!;
    public string Senha { get; set; } = default!;
    public string Email { get; set; } = default!;
    public DateTime DataDeCriacao { get; set; }
}
