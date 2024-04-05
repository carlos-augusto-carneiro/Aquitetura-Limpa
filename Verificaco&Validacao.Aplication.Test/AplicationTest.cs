using AutoMapper;
using Moq;
using Verificacao_Validacao.Aplication.UseCase.Usuarios.Adicionar;
using Verificacao_Validacao.Domain.Interfaces;
using Verificacao_Validacao.Domain.Models;

namespace Verificaco_Validacao.Aplication.Test
{
    [TestClass]
    public class AplicationTest
    {
        [TestMethod]
        public void TesteHandle_AdicionarUsuarioComSucesso()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var usuarioServiceMock = new Mock<IUsuario>();

            var request = new AdicionarUsuarioRequest("Teste", "teste@example.com", "senha123", DateTime.Now);
            var usuario = new Usuario { Name = request.Name, Email = request.Email, Senha = request.Senha, DataDeCriacao = request.DatadeCriacao };
            var responseEsperada = new AdicionarUsuarioResponse { Name = usuario.Name, Email = usuario.Email, Senha = usuario.Senha, DataDeCriacao = usuario.DataDeCriacao };

            mapperMock.Setup(m => m.Map<Usuario>(request)).Returns(usuario);
            usuarioServiceMock.Setup(u => u.Cadastrar(usuario));

            var handler = new AdicionarUsuarioHandler(mapperMock.Object, usuarioServiceMock.Object);

            // Act
            var resultado = handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.IsInstanceOfType(resultado.Result, typeof(AdicionarUsuarioResponse));
            Assert.AreEqual(responseEsperada.Name, resultado.Result.Name);
            Assert.AreEqual(responseEsperada.Email, resultado.Result.Email);
            Assert.AreEqual(responseEsperada.Senha, resultado.Result.Senha);
            Assert.AreEqual(responseEsperada.DataDeCriacao, resultado.Result.DataDeCriacao);
        }
    }
}
