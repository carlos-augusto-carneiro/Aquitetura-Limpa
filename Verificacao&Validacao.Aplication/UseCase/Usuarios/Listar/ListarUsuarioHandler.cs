using AutoMapper;
using MediatR;
using Verificacao_Validacao.Domain.Interfaces;

namespace Verificacao_Validacao.Aplication.UseCase.Usuarios.Listar;

public sealed class ListarUsuarioHandler : IRequestHandler<ListarUsuarioRequest, List<ListarUsuarioResponse>>
{
    private readonly IMapper _mapper;
    private readonly IUsuario _usuario;

    public ListarUsuarioHandler(IMapper mapper, IUsuario usuario)
    {
        _mapper = mapper;
        _usuario = usuario;
    }

    public Task<List<ListarUsuarioResponse>> Handle(ListarUsuarioRequest request, CancellationToken cancellationToken)
    {
        var listar = _usuario.Listar();
        var response = _mapper.Map<List<ListarUsuarioResponse>>(listar);

        return Task.FromResult(response);
    }
}
