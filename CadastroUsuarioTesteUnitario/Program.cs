using CadastroUsuarioTesteUnitario;
using CadastroUsuarioTesteUnitario.Dominio;

namespace CadastroUsuarioTesteUnitario
{
    public class Program
    {
        static void Main()
        {
            var cadastro = new ServicoDeDominioDeCadastroDeUsuario();
            cadastro.CadastrarUsuario("João", "joao@email.com", 28);

            foreach (var u in cadastro.ObterUsuarios())
            {
                Console.WriteLine($"{u.Nome}, {u.Email}, {u.Idade}");
            }
        }
    }
}