using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.Utilidades;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public enum StatusEmprestimo
{
    Indefinido,
    Aberto,
    Concluido,
    Atrasado
}

public class Emprestimo : EntidadeBase
{
    public Amigo Amigo { get; private set; }
    public Revista Revista { get; private set; }
    public StatusEmprestimo Status { get; set; }
    public DateTime DataAbertura { get; private set; }
    public DateTime DataConclusaoPrevista
    {
        get
        {
            int DiasDeEmprestimo = Revista.Caixa.DiasDeEmprestimo;

            DateTime dataConclusaoPrevista = DataAbertura.AddDays(DiasDeEmprestimo);

            return dataConclusaoPrevista;
        }
    }
    public bool EstaAberto
    {
        get
        {
            return Status != StatusEmprestimo.Aberto;
        }
    }

    public Emprestimo(Amigo amigo, Revista revista)
    {
        Id = GeradorIds.ObterIdEmprestimo();
        DataAbertura = DateTime.Now;
        Status = StatusEmprestimo.Aberto;

        Amigo = amigo;
        Revista = revista;
    }

    public void Abrir()
    {
        Status = StatusEmprestimo.Aberto;
        Revista.Emprestar();
    }
    public void Concluir()
    {
        Status = StatusEmprestimo.Concluido;
        Revista.Devolver();
    }
    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Emprestimo emprestimoAtualizado = (Emprestimo)entidadeAtualizada;

        Status = emprestimoAtualizado.Status;
    }
}
