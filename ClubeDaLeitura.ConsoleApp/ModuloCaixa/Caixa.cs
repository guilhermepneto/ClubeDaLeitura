using ClubeDaLeitura.ConsoleApp.Utilidades;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

public class Caixa
{
    public int Id { get; private set; }
    public string Etiqueta { get; private set; }
    public string Cor { get; private set; }
    public int DiasDeEmprestimo { get; private set; }

    public Caixa(string etiqueta, string cor, int diasDeEmprestimo)
    {
        Id = GeradorIds.ObterIdCaixa();

        Etiqueta = etiqueta;
        Cor = cor;
        DiasDeEmprestimo = diasDeEmprestimo;
    }

    public void Atualizar(Caixa caixaAtualizada)
    {
        Etiqueta = caixaAtualizada.Etiqueta;
        Cor = caixaAtualizada.Cor;
        DiasDeEmprestimo = caixaAtualizada.DiasDeEmprestimo;
    }
}
