using Verificacao_Validacao.Domain.Models;

namespace Verificacao_Validacao.Domain.Interfaces;

public interface IUsuario : IBase<Usuario> 
{
    public void Atualizar(Guid Id, Usuario usuario);
}
