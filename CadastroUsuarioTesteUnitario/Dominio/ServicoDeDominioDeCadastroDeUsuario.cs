using CadastroUsuarioTesteUnitario.Models;

namespace CadastroUsuarioTesteUnitario.Dominio
{
    public class ServicoDeDominioDeCadastroDeUsuario
    {
        private readonly List<Usuario> _usuarios = new();

        public void CadastrarUsuario(string nome, string email, int idade)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome é obrigatório.");

            if (!email.Contains("@") || !email.Contains("."))
                throw new ArgumentException("Email inválido.");

            if (idade < 18)
                throw new ArgumentException("Usuário deve ter pelo menos 18 anos.");

            _usuarios.Add(new Usuario { Nome = nome, Email = email, Idade = idade });
        }

        public IEnumerable<Usuario> ObterUsuarios() => _usuarios;
    }
}