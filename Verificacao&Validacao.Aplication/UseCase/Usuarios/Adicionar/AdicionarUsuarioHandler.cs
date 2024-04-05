using AutoMapper;
using MediatR;
using Verificacao_Validacao.Aplication.Service.Security;
using Verificacao_Validacao.Domain.Interfaces;
using Verificacao_Validacao.Domain.Models;

namespace Verificacao_Validacao.Aplication.UseCase.Usuarios.Adicionar;

public sealed class AdicionarUsuarioHandler : IRequestHandler<AdicionarUsuarioRequest, AdicionarUsuarioResponse>
{
    private readonly IMapper _mapper;
    private readonly IUsuario _usuario;

    public AdicionarUsuarioHandler(IMapper mapper, IUsuario usuario)
    {
        _mapper = mapper;
        _usuario = usuario;
    }

    public Task<AdicionarUsuarioResponse> Handle(AdicionarUsuarioRequest request, CancellationToken cancellationToken)
    {
        var mapearRequest = _mapper.Map<Usuario>(request);
        mapearRequest.Senha = mapearRequest.Senha.GerarHash();
        _usuario.Cadastrar(mapearRequest);
        var mapearReponse = _mapper.Map<AdicionarUsuarioResponse>(mapearRequest);

        return Task.FromResult(mapearReponse);
    }
}
