using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Utilidades;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class Amigo : EntidadeBase
{
    public string Nome { get; private set; }
    public string NomeResponsavel { get; private set; }
    public string Telefone { get; private set; }

    public Amigo(string nome, string nomeResponsavel, string telefone)
    {
        Id = GeradorIds.ObterIdAmigo();
        Nome = nome;
        NomeResponsavel = nomeResponsavel;
        Telefone = telefone;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Amigo amigoAtualizado = (Amigo)entidadeAtualizada;

        Nome = amigoAtualizado.nome;
        NomeResponsavel = amigoAtualizado.nomeResponsavel;
        Telefone = amigoAtualizado.telefone;
    }
}
