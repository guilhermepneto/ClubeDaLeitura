namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

public class Caixa
{
    public string Etiqueta { get; private set; }
    public string Cor { get; private set; }
    public int DiasDeEmprestimo { get; private set; }

    public Caixa(string etiqueta, string cor, int diasDeEmprestimo)
    {
        Etiqueta = etiqueta;
        Cor = cor;
        DiasDeEmprestimo = diasDeEmprestimo;
    }
}
