using Verificacao_Validacao.API.Controllers;
using Verificacao_Validacao.Domain.Interfaces;

namespace Verificacao_Validacao.Test
{
    [TestClass]
    public class UsuarioControllerTest
    {
        //Testes//
        /*
            Teste para cadastrar usuario
            Teste para deletar usuario
            Teste para listar usuarios
            Teste para atualizar usuario        
        */
        [TestMethod]
        public void TesteCadastrarUsuario()
        {
            var Service = new Mock<IUsuario>();
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}