using AutoMapper;
using Verificacao_Validacao.Domain.Models;

namespace Verificacao_Validacao.Aplication.UseCase.Usuarios.Atualizar;

public sealed class AtualizarUsuarioMap : Profile
{
    public AtualizarUsuarioMap()
    {
        CreateMap<AtualizarUsuarioRequest, Usuario>();
    }
}
