using Microsoft.EntityFrameworkCore;
using Verificacao_Validacao.Domain.Models;
using Verificacao_Validacao.Persistence.Context;
using Verificacao_Validacao.Persistence.Repository;

namespace Verificacao_Validacao.Test.Verificacao_Validacao.Test.Infra;

[TestClass]
public class TestInfra
{
    private DbContextOptions<DbUsuario> _context;

    [TestInitialize]
    public void Init()
    {
        _context = new DbContextOptionsBuilder<DbUsuario>().UseInMemoryDatabase(databaseName: "TesteDbUsuario").Options;
    }
    [TestMethod]
    public void TestarAddUsuario()
    {
        using (var context = new DbUsuario(_context))
        {
            var repository = new UsuarioRepository(context);
            var usuario = new Usuario { Id = Guid.NewGuid(), Name = "Teste", Email = "teste@teste.com", Senha = "senha1234", DataDeCriacao = DateTime.Now };

            repository.Cadastrar(usuario);

            var usuarioSalvo = context.Usuarios.FirstOrDefault(u => u.Id == usuario.Id);
            Assert.IsNotNull(usuarioSalvo);
            Assert.AreEqual(usuario.Name, usuarioSalvo.Name);
            Assert.AreEqual(usuario.Email, usuarioSalvo.Email);
        }
    }

    [TestMethod]
    public void TestarDeletarUsuario()
    {
        using (var context = new DbUsuario(_context))
        {
            var usuarioId = Guid.NewGuid();
            using (var contexto = new DbUsuario(_context))
            {
                var repository = new UsuarioRepository(context);
                var usuario = new Usuario { Id = usuarioId, Name = "Teste", Email = "teste@teste.com", Senha = "senha1234", DataDeCriacao = DateTime.Now };
                context.Usuarios.Add(usuario);
                context.SaveChanges();

                repository.Deletar(usuarioId);

                var usuarioDeletado = context.Usuarios.FirstOrDefault(u => u.Id == usuarioId);
                Assert.IsNull(usuarioDeletado);
            }
        }
    }
    [TestMethod]
    public void TestarAtualizarUsuario()
    {
        using (var context = new DbUsuario(_context))
        {

            var usuarioId = Guid.NewGuid();
            var usuarioInicial = new Usuario { Id = usuarioId, Name = "Carlos", Email = "teste@teste.com", Senha = "senha1234", DataDeCriacao = DateTime.Now };
            context.Usuarios.Add(usuarioInicial);
            context.SaveChanges();

            var repository = new UsuarioRepository(context);

            var novosDadosUsuario = new Usuario { Id = usuarioId, Name = "Carlos Carneiro", Email = "carlos@hotmail.com", Senha = "123456789", DataDeCriacao = DateTime.Now };

            repository.Atualizar(usuarioId, novosDadosUsuario);

            var usuarioAtualizado = context.Usuarios.FirstOrDefault(u => u.Id == usuarioId);

            Assert.IsNotNull(usuarioAtualizado);
            Assert.AreEqual(novosDadosUsuario.Name, usuarioAtualizado.Name);
            Assert.AreEqual(novosDadosUsuario.Email, usuarioAtualizado.Email);
            Assert.AreEqual(novosDadosUsuario.Senha, usuarioAtualizado.Senha);
        }
    }
}
