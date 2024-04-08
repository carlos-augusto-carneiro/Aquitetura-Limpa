using MediatR;
using Microsoft.AspNetCore.Mvc;
using Verificacao_Validacao.Aplication.UseCase.Usuarios.Adicionar;
using Verificacao_Validacao.Aplication.UseCase.Usuarios.Atualizar;
using Verificacao_Validacao.Aplication.UseCase.Usuarios.Deletar;
using Verificacao_Validacao.Aplication.UseCase.Usuarios.Listar;

namespace Verificacao_Validacao.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsuarioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("/AdicionarUsuario")]
    public IActionResult AddUsuario(AdicionarUsuarioRequest request)
    {
        var validador = new AdicionarUsuarioValidation();
        var validadorResult = validador.Validate(request);
        if (!validadorResult.IsValid)
        {
            return BadRequest(validadorResult.Errors);
        }
        else
        {
            var resposta = _mediator.Send(request);
            return Ok(resposta);
        }
        
    }

    [HttpPut("/AtualizarUsuario")]
    public IActionResult PutUsuario(AtualizarUsuarioRequest request)
    {
        var validador = new AtualizarUsuarioValidation();
        var validadorResult = validador.Validate(request);
        if (!validadorResult.IsValid)
        {
            return BadRequest(validadorResult.Errors);
        }
        else
        {
            var resposta = _mediator.Send(request);
            return Ok(resposta);
        }
    }

    [HttpDelete("/DeletarUsuario")]
    public IActionResult DelUsuario(DeletarUsuarioRequest request)
    {
        var reponse = _mediator.Send(request);
        if(reponse != null)
        {
            return Ok(reponse);
        }
        else
        {
            return BadRequest("Usuario não encotrado");
        }
    }

    [HttpGet("/ListarUsuarios")]
    public async Task<IActionResult> ListsUsuarios()
    {
        var contador = await _mediator.Send(new ListarUsuarioRequest());
        return Ok(contador);
    }
}
