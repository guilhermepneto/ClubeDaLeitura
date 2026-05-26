namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

public class RepositorioCaixa
{
    private Caixa[] registros = new Caixa[100];

    public void Cadastrar(Caixa novaCaixa)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
            {
                registros[i] = novaCaixa;
                break;
            }
        }
    }
}