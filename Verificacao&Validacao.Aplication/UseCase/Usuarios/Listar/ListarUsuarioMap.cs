using AutoMapper;
using Verificacao_Validacao.Domain.Models;

namespace Verificacao_Validacao.Aplication.UseCase.Usuarios.Listar;

public sealed class ListarUsuarioMap : Profile
{
    public ListarUsuarioMap()
    {
        CreateMap<Usuario, ListarUsuarioResponse>();
    }
}
