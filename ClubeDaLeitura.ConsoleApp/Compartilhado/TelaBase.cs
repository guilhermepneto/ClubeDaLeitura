namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public abstract class TelaBase
{
    private string nomeEntidade = string.Empty;
    private RepositorioBase repositorio;

    protected TelaBase(string nomeEntidade, RepositorioBase repositorio)
    {
        this.nomeEntidade = nomeEntidade;
        this.repositorio = repositorio;
    }

    public string? ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------");
        Console.WriteLine($"Gestão de {nomeEntidade}s");
        Console.WriteLine($"---------------------------");
        Console.WriteLine($"1 - Cadastrar {nomeEntidade}");
        Console.WriteLine($"2 - Editar {nomeEntidade}");
        Console.WriteLine($"3 - Excluir {nomeEntidade}");
        Console.WriteLine($"4 - Visualizar {nomeEntidade}s");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------");
        Console.Write("> ");

        string? opcaoMenuInterno = Console.ReadLine()?.ToUpper();

        return opcaoMenuInterno;
    }

    public void Cadastar()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Cadastro de {nomeEntidade}");
        Console.WriteLine("---------------------------------");

        EntidadeBase novaEntidade = ObterDadosCadastrais();

        repositorio.Cadastrar(novaEntidade);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro \"{novaEntidade.Id}\" foi cadastrado com sucesso!");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar");
        Console.ReadLine();
    }

    protected abstract EntidadeBase ObterDadosCadastrais();

}
