using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class TelaAmigo : TelaBase, ITelaOpcoes
{
    private readonly RepositorioAmigo repositorioAmigo;
    private readonly RepositorioEmprestimo repositorioEmprestimo;

    public TelaAmigo(
        string nomeEntidade,
        RepositorioAmigo repositorioAmigo,
        RepositorioEmprestimo repositorioEmprestimo) : base(nomeEntidade, repositorioAmigo)
    {
        this.repositorioAmigo = repositorioAmigo;
        this.repositorioEmprestimo = repositorioEmprestimo;
    }

    public override string? ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------");
        Console.WriteLine($"Gestão de Amigos");
        Console.WriteLine($"---------------------------");
        Console.WriteLine($"1 - Cadastrar Amigo");
        Console.WriteLine($"2 - Editar Amigo");
        Console.WriteLine($"3 - Excluir Amigo");
        Console.WriteLine($"4 - Visualizar Amigos");
        Console.WriteLine($"5 - Visualizar empréstimos de um amigo");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------");
        Console.Write("> ");

        string? opcaoMenuInterno = Console.ReadLine()?.ToUpper();

        return opcaoMenuInterno;
    }

    public void VisualizarEmprestimoAmigo()
    {
        Console.WriteLine("---------------------------");
        Console.WriteLine("Visualização de Emprestrimo de migo");
        Console.WriteLine("---------------------------");

        VisualizarTodos(false);

        Console.WriteLine("---------------------------------");

        Console.Write("Digite o ID do amigo que deseja ver os empréstimos: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("---------------------------------");

        Amigo? amigoSelecionado = (Amigo?)repositorioAmigo.SelecionarPorId(idSelecionado);

        if (amigoSelecionado == null)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"O amigo \"{idSelecionado}\" não foi encontrado!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Presione ENTER para continuar");
            Console.ReadLine();
            return;
        }

        Console.WriteLine($"Empréstimo de \"{amigoSelecionado.Nome}\"");
        Console.WriteLine("---------------------------------");

        EntidadeBase[] emprestimos = repositorioEmprestimo.SelecionarTodos();

        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -15} | {3, -17} | {4, -15}",
            "Id", "Revista", "Abertura", "Conclusão Prev.", "Status"
     );

        for (int i = 0; i < emprestimos.Length; i++)
        {
            Emprestimo e = (Emprestimo)emprestimos[i];

            if (e == null)
                continue;

            if (e.Amigo.Id != amigoSelecionado.Id)
                continue;

            Console.WriteLine(
         "{0, -7} | {1, -15} | {2, -15} | {3, -17} | {4, -15}",
         e.Id, e.Revista.Titulo, e.DataAbertura.ToShortDateString(), e.DataConclusaoPrevista.ToShortDateString(), e.Status.ToString()
         );
        }

        Console.WriteLine("---------------------------");
        Console.WriteLine("Pressione ENTER para prosseguir.");
        Console.ReadLine();
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

        for (int i = 0; i < amigos.Length; i++)
        {
            Amigo a = (Amigo)amigos[i];

            if (a == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -15} | {3, -13}",
                a.Id, a.Nome, a.NomeResponsavel, a.Telefone
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
        Console.Write("Informe o nome do amigo: ");
        string? nome = Console.ReadLine();

        Console.Write("Informe o nome do responsável do amigo: ");
        string? nomeResponsavel = Console.ReadLine();

        Console.Write("Informe o telefone do amigo (ou responsável): ");
        string? telefone = Console.ReadLine();

        return new Amigo(nome, nomeResponsavel, telefone);
    }
}
