using AutoMapper;
using MediatR;
using Verificacao_Validacao.Aplication.Service.Security;
using Verificacao_Validacao.Domain.Interfaces;
using Verificacao_Validacao.Domain.Models;

namespace Verificacao_Validacao.Aplication.UseCase.Usuarios.Atualizar;

public sealed class AtualizarUsuarioHandler : IRequestHandler<AtualizarUsuarioRequest, AtualizarUsuarioResponse>
{
    private readonly IMapper _mapper;
    private readonly IUsuario _usuario;

    public AtualizarUsuarioHandler(IMapper mapper, IUsuario usuario)
    {
        _mapper = mapper;
        _usuario = usuario;
    }

    public Task<AtualizarUsuarioResponse> Handle(AtualizarUsuarioRequest request, CancellationToken cancellationToken)
    {
        var mapearRequest = _mapper.Map<Usuario>(request);
        mapearRequest.Senha = mapearRequest.Senha.GerarHash();
        _usuario.Atualizar(mapearRequest.Id, mapearRequest);

        var response = new AtualizarUsuarioResponse();

        return Task.FromResult(response);
    }
}
