namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public abstract class TelaBase
{
    private string nomeEntidade = string.Empty;

    protected TelaBase(string nomeEntidade)
    {
        this.nomeEntidade = nomeEntidade;
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

}
