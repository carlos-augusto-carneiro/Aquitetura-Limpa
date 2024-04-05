using AutoMapper;
using MediatR;
using Verificacao_Validacao.Domain.Interfaces;
using Verificacao_Validacao.Domain.Models;

namespace Verificacao_Validacao.Aplication.UseCase.Usuarios.Deletar;

public sealed class DeletarUsuarioHandler : IRequestHandler<DeletarUsuarioRequest, DeletarUsuarioResponse>
{
    private readonly IMapper _mapper;
    private readonly IUsuario _usuario;

    public DeletarUsuarioHandler(IMapper mapper, IUsuario usuario)
    {
        _mapper = mapper;
        _usuario = usuario;
    }

    public Task<DeletarUsuarioResponse> Handle(DeletarUsuarioRequest request, CancellationToken cancellationToken)
    {
        var mapearRequest = _mapper.Map<Usuario>(request);
        _usuario.Deletar(mapearRequest.Id);
        var mapearReponse = _mapper.Map<DeletarUsuarioResponse>(mapearRequest);

        return Task.FromResult(mapearReponse);
    }
}
