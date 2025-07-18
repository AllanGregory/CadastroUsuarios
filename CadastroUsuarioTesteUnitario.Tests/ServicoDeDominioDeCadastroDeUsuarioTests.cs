using CadastroUsuarioTesteUnitario.Dominio;
using Xunit;

namespace CadastroUsuarioTesteUnitario.Tests
{
    public class ServicoDeDominioDeCadastroDeUsuarioTests
    {
        [Fact]
        public void DeveCadastrarUsuarioValido()
        {
            var dominio = new ServicoDeDominioDeCadastroDeUsuario();

            dominio.CadastrarUsuario("Allan", "allan@gmail.com", 33);

            var usuarios = dominio.ObterUsuarios();
            Assert.Single(usuarios);
            Assert.Equal("Allan", usuarios.First().Nome);
        }

        [Theory]
        [InlineData("", "email@email.com", 25, "Nome é obrigatório.")]
        [InlineData("João", "emailemail.com", 25, "Email inválido.")]
        [InlineData("João", "email@email.com", 17, "Usuário deve ter pelo menos 18 anos.")]
        public void DeveLancarExcecaoParaDadosInvalidos(string nome, string email, int idade, string mensagemEsperada)
        {
            var dominio = new ServicoDeDominioDeCadastroDeUsuario();

            var excecao = Assert.Throws<ArgumentException>(() =>
                dominio.CadastrarUsuario(nome, email, idade));

            Assert.Equal(mensagemEsperada, excecao.Message);
        }
    }
}