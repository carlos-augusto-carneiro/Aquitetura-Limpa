using AutoMapper;
using Verificacao_Validacao.Domain.Models;

namespace Verificacao_Validacao.Aplication.UseCase.Usuarios.Adicionar;

public sealed class AdicionaUsuarioMap : Profile
{
    public AdicionaUsuarioMap()
    {
        CreateMap<AdicionarUsuarioRequest, Usuario>();
        CreateMap<Usuario, AdicionarUsuarioResponse>();
    }
}
