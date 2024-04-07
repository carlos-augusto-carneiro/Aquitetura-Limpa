namespace Verificacao_Validacao.Domain.Models;

public class Usuario : ClassBase
{
    public string Name { get; set; } = default!;
    public string Senha { get; set; } = default!;
    public string Email { get; set; } = default!;
    public DateTime DataDeCriacao { get; set; }
}
