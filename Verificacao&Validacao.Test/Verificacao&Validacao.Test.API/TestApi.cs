using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verificacao_Validacao.API.Controllers;
using Verificacao_Validacao.Aplication.UseCase.Usuarios.Adicionar;

namespace Verificacao_Validacao.Test.Verificacao_Validacao.Test.API;

[TestClass]
public class TestApi
{
    private UsuarioController _controller;
    private Mock<IMediator> _mediator;

    [TestInitialize]
    public void Init()
    {
        _mediator = new Mock<IMediator>();
        _controller = new UsuarioController(_mediator.Object);
    }

    [TestMethod]
    public async Task TestarAddUsuaroAPIAsync()
    {
        // Arrange
        var request = new AdicionarUsuarioRequest("Nome", "email@example.com", "senha123", DateTime.Now);
        var response = new AdicionarUsuarioResponse();
        _mediator.Setup(m => m.Send(request, default(CancellationToken))).Returns(Task.FromResult(response));

        // Act
        var actionResult = await _controller.AddUsuario(request);

        // Assert
        var okResult = actionResult as OkObjectResult;
        Assert.IsNotNull(okResult);
        Assert.AreEqual(200, okResult.StatusCode);
        // Faça mais verificações conforme necessário
    }
}
