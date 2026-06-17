using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

public class TelaCaixa : TelaBase, ITelaOpcoes
{
    private readonly RepositorioCaixa repositorioCaixa;
    private readonly RepositorioRevista repositorioRevista;

    public TelaCaixa(
        string nomeEntidade,
        RepositorioCaixa repositorioCaixa,
        RepositorioRevista repositorioRevista) : base(nomeEntidade, repositorioCaixa)
    {
        this.repositorioCaixa = repositorioCaixa;
        this.repositorioRevista = repositorioRevista;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Visualização de Caixas");
            Console.WriteLine("---------------------------");
        }

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10} | {3, -20}",
            "Id", "Etiqueta", "Cor", "Tempo de Empréstimo"
        );

        EntidadeBase[] registros = repositorioCaixa.SelecionarTodos();

        for (int i = 0; i < registros.Length; i++)
        {
            Caixa c = (Caixa)registros[i];

            if (c == null)
                continue;

            Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10} | {3, -20}",
            c.Id, c.Etiqueta, c.Cor, c.DiasDeEmprestimo
        );
        }

        if (deveExibirCabecalho)
        {

            Console.WriteLine("---------------------------");
            Console.WriteLine("Pressione ENTER para prosseguir.");
            Console.ReadLine();
        }

    }

    protected override EntidadeBase ObterDadosCadastrais()
    {
        Console.WriteLine("Informe a etiqueta da caixa:");
        string? etiqueta = Console.ReadLine();

        Console.WriteLine("Informe a cor da caixa:");
        string? cor = Console.ReadLine();

        Console.WriteLine("Informe o tempo de empréstimo da caixa:");
        int diasDeEmprestimo = Convert.ToInt32(Console.ReadLine());

        Caixa novaCaixa = new Caixa(etiqueta, cor, diasDeEmprestimo);

        return novaCaixa;

    }
}
