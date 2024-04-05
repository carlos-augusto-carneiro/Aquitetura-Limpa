using Verificacao_Validacao.Domain.Models;

namespace Verificacao_Validacao.Domain.Interfaces;

public interface IBase<T> where T : ClassBase
{
    public void Cadastrar(T t);
    public void Deletar(Guid Id);
    public List<T> Listar();
}
