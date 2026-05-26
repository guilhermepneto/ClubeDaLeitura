namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

public class TelaCaixa
{
    public string? ObterOpcaoMenu()
    {
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
}
