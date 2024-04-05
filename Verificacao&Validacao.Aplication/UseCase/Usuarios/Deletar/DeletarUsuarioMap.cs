using AutoMapper;
using Verificacao_Validacao.Domain.Models;

namespace Verificacao_Validacao.Aplication.UseCase.Usuarios.Deletar;

public sealed class DeletarUsuarioMap : Profile
{
    public DeletarUsuarioMap()
    {
        CreateMap<DeletarUsuarioRequest, Usuario>();
        CreateMap<Usuario, DeletarUsuarioResponse>();
    }
}
