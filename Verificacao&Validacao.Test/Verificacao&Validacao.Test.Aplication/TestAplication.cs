using AutoMapper;
using Moq;
using Verificacao_Validacao.Aplication.UseCase.Usuarios.Adicionar;
using Verificacao_Validacao.Aplication.UseCase.Usuarios.Atualizar;
using Verificacao_Validacao.Aplication.UseCase.Usuarios.Deletar;
using Verificacao_Validacao.Aplication.UseCase.Usuarios.Listar;
using Verificacao_Validacao.Domain.Interfaces;
using Verificacao_Validacao.Domain.Models;

namespace Verificacao_Validacao.Test.Verificacao_Validacao.Test.Aplication;

[TestClass]
public class TestAplication
{
    private AdicionarUsuarioHandler _handler;
    private AtualizarUsuarioHandler _handlerAtualizar;
    private DeletarUsuarioHandler _hanlderDeletar;
    private ListarUsuarioHandler _handlerListar;

    private Mock<IMapper> _mapper;
    private Mock<IUsuario> _usuario;

    [TestInitialize]
    public void Init()
    {
        _mapper = new Mock<IMapper>();
        _usuario = new Mock<IUsuario>();

        _handler = new AdicionarUsuarioHandler(_mapper.Object, _usuario.Object);

        _hanlderDeletar = new DeletarUsuarioHandler(_mapper.Object, _usuario.Object);

        _handlerListar = new ListarUsuarioHandler(_mapper.Object, _usuario.Object);

        _handlerAtualizar = new AtualizarUsuarioHandler(_mapper.Object, _usuario.Object);
    }


    [TestMethod]
    [DataRow("Carlos","carlos@hotmail.com","12345678", "07-04-2024")]
    [DataRow("Pedor", "carlos", "12345678", "07-04-2024")]
    [DataRow("Maria", "", "", "07-04-2024")]
    [DataRow("Eloan", "carlos@hotmail.com", "1234567", "07-04-2024")]
    [DataRow("Carlos", "carlos@hotmail.com", "12345678", "06-04-2024")]
    public void TestAdicionarCERTO(string nome, string email, string senha, string dataString)
    {
        DateTime data = DateTime.Parse(dataString);

        var validador = new AdicionarUsuarioValidation();
        var request = new AdicionarUsuarioRequest(nome, email, senha, data);
        var response = new AdicionarUsuarioResponse
        {
            Name = request.Name,
            Email = request.Email,
            Senha = request.Senha,
            DataDeCriacao = request.DatadeCriacao
        };

        var resultadoValidador = validador.Validate(request);
        Assert.IsTrue(resultadoValidador.IsValid, "O request não passou na validacao");

        _mapper.Setup(m => m.Map<Usuario>(request)).Returns(new Usuario());
        _mapper.Setup(m => m.Map<AdicionarUsuarioResponse>(It.IsAny<Usuario>())).Returns(response);
        
        var metHandle = _handler.Handle(request, CancellationToken.None).Result;

        Assert.AreEqual(response.Name, metHandle.Name);
        Assert.AreEqual(response.Email, metHandle.Email);
        Assert.AreEqual(response.DataDeCriacao, metHandle.DataDeCriacao);
        _usuario.Verify(u => u.Cadastrar(It.IsAny<Usuario>()), Times.Once);
    }

    [TestMethod]
    public void TestDeletarUsuario()
    {
        var idUsuario = Guid.NewGuid();
        var request = new DeletarUsuarioRequest(idUsuario);

        _mapper.Setup(m => m.Map<Usuario>(request)).Returns(new Usuario { Id = idUsuario });

        _hanlderDeletar.Handle(request, CancellationToken.None);

        _usuario.Verify(u => u.Deletar(idUsuario), Times.Once);
    }

    [TestMethod]
    public void TestListarUsuarios()
    {
        var usuarios = new List<Usuario>
        {
            new Usuario { Id = Guid.NewGuid(), Name = "Carlos", Email = "carlos@hotmail.com", DataDeCriacao = DateTime.Now },
            new Usuario { Id = Guid.NewGuid(), Name = "Eloan", Email = "eloan@gmail.com", DataDeCriacao = DateTime.Now }
        };
        _usuario.Setup(u => u.Listar()).Returns(usuarios);

        var expectedResponse = usuarios.Select(u => new ListarUsuarioResponse
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email,
            DataDeCriacao = u.DataDeCriacao
        }).ToList();

        _mapper.Setup(m => m.Map<List<ListarUsuarioResponse>>(usuarios)).Returns(expectedResponse);
        var response = _handlerListar.Handle(new ListarUsuarioRequest(), CancellationToken.None).Result;

        CollectionAssert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void TestAtualizarUsuario()
    {
        // Arrange
        var request = new AtualizarUsuarioRequest(Guid.NewGuid(), "Novo Nome", "novoemail@example.com", "novasenha123");

        var usuarioAtualizado = new Usuario
        {
            Id = request.Id,
            Name = request.Name,
            Email = request.Email,
            Senha = request.Senha
        };

        _mapper.Setup(m => m.Map<Usuario>(request)).Returns(usuarioAtualizado);

        var responseTask = _handlerAtualizar.Handle(request, CancellationToken.None);
        responseTask.Wait(); 

        var response = responseTask.Result;
        Assert.IsNotNull(response); 
    }
}
