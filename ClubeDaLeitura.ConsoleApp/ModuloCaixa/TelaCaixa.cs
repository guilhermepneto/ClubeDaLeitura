namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

public class TelaCaixa
{

    private RepositorioCaixa repositorioCaixa;

    public TelaCaixa(RepositorioCaixa repositorioCaixa)
    {
        this.repositorioCaixa = repositorioCaixa;
    }
    public string? ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------");
        Console.WriteLine("Gestão de Caixas");
        Console.WriteLine("---------------------------");
        Console.WriteLine("1 - Cadastrar Caixa");
        Console.WriteLine("2 - Editar Caixa");
        Console.WriteLine("3 - Excluir Caixa");
        Console.WriteLine("4 - Visualizar Caixas");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------");
        Console.Write("> ");

        string? opcaoMenuInterno = Console.ReadLine()?.ToUpper();

        return opcaoMenuInterno;
    }

    public void Cadastar()
    {
        Console.WriteLine("---------------------------");
        Console.WriteLine("Cadastro de Caixas");
        Console.WriteLine("---------------------------");

        Caixa novaCaixa = ObterDadosCadastrais();

        repositorioCaixa.Cadastrar(novaCaixa);

        Console.WriteLine("---------------------------");
        Console.WriteLine($"O registro \"{novaCaixa.Etiqueta}\" foi cadastrado com sucesso!");
        Console.WriteLine("---------------------------");
        Console.WriteLine("Pressione ENTER para prosseguir.");
        Console.ReadLine();
    }

    public void Editar()
    {
        Console.WriteLine("---------------------------");
        Console.WriteLine("Edição de Caixa");
        Console.WriteLine("---------------------------");

        VisualizarTodos(false);

        Console.WriteLine("---------------------------");
        Console.Write("Digite o ID do registro que deseja editar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Caixa caixaAtualizada = ObterDadosCadastrais();

        repositorioCaixa.Editar(idSelecionado, caixaAtualizada);

        Console.WriteLine("---------------------------");
        Console.WriteLine($"O registro \"{caixaAtualizada.Etiqueta}\" foi editado com sucesso!");
        Console.WriteLine("---------------------------");
        Console.WriteLine("Pressione ENTER para prosseguir.");
        Console.ReadLine();

    }

    public void Excluir()
    {
        Console.WriteLine("---------------------------");
        Console.WriteLine("Exclusão de Caixa");
        Console.WriteLine("---------------------------");

        VisualizarTodos(false);

        Console.WriteLine("---------------------------");
        Console.Write("Digite o ID do registro que deseja excluir: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        repositorioCaixa.Excluir(idSelecionado);

        Console.WriteLine("---------------------------");
        Console.WriteLine($"O registro \"{idSelecionado}\" foi excluído com sucesso!");
        Console.WriteLine("---------------------------");
        Console.WriteLine("Pressione ENTER para prosseguir.");
        Console.ReadLine();
    }

    public void VisualizarTodos(bool deveExibirCabecalho)
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

        Caixa[] registros = repositorioCaixa.SelecionarTodos();

        for (int i = 0; i < registros.Length; i++)
        {
            Caixa c = registros[i];

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

    private Caixa ObterDadosCadastrais()
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
