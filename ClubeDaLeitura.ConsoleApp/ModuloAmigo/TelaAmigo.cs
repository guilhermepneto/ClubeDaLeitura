using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class TelaAmigo : TelaBase
{
    private readonly RepositorioAmigo repositorioAmigo;

    public TelaAmigo(
        string nomeEntidade,
        RepositorioAmigo repositorioAmigo) : base(nomeEntidade, repositorioAmigo)
    {
        this.repositorioAmigo = repositorioAmigo;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Visualização de Amigos");
            Console.WriteLine("---------------------------");
        }

        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -15} | {3, -13}",
            "Id", "Nome", "Responsável", "Telefone"
            );

        EntidadeBase[] amigos = repositorioAmigo.SelecionarTodos();


        if (deveExibirCabecalho)
        {

            Console.WriteLine("---------------------------");
            Console.WriteLine("Pressione ENTER para prosseguir.");
            Console.ReadLine();
        }
    }

    protected override EntidadeBase ObterDadosCadastrais()
    {
        Console.Write("Informe o nome do amigo: ");
        string? nome = Console.ReadLine();

        Console.Write("Informe o nome do responsável do amigo: ");
        string? nomeResponsavel = Console.ReadLine();

        Console.Write("Informe o telefone do amigo (ou responsável): ");
        string? telefone = Console.ReadLine();

        return new Amigo(nome, nomeResponsavel, telefone);
    }
}
