using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class TelaEmprestimo : ITelaOpcoes
{
    private readonly RepositorioEmprestimo repositorioEmprestimo;
    private readonly RepositorioRevista repositorioRevista;
    private readonly RepositorioAmigo repositorioAmigo;

    public TelaEmprestimo(
        RepositorioEmprestimo repositorioEmprestimo,
        RepositorioRevista repositorioRevista,
        RepositorioAmigo repositorioAmigo
        )
    {
        this.repositorioEmprestimo = repositorioEmprestimo;
        this.repositorioRevista = repositorioRevista;
        this.repositorioAmigo = repositorioAmigo;
    }
    public string? ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------");
        Console.WriteLine($"Gestão de Empréstimos");
        Console.WriteLine($"---------------------------");
        Console.WriteLine($"1 - Abrir Empréstimos");
        Console.WriteLine($"2 - Concluir Empréstimos");
        Console.WriteLine($"3 - Excluir Empréstimos");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------");
        Console.Write("> ");

        string? opcaoMenuInterno = Console.ReadLine()?.ToUpper();

        return opcaoMenuInterno;
    }

    public void Abrir()
    {
        Console.WriteLine("---------------------------");
        Console.WriteLine("Abertura de Empréstimos");
        Console.WriteLine("---------------------------");

        VisualizarRevistas();

        Console.WriteLine("---------------------------");
        Console.Write("Digite o ID da revista que deseja emprestar: ");
        int idRevista = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("---------------------------");

        VisualizarAmigos();

        Console.WriteLine("---------------------------");
        Console.Write("Digite o ID do amigo que irá receber a revista: ");
        int idAmigo = Convert.ToInt32(Console.ReadLine());


        Revista? revistaSelecionada = (Revista?)repositorioRevista.SelecionarPorId(idRevista);
        Amigo? amigoSelecionado = (Amigo?)repositorioAmigo.SelecionarPorId(idAmigo);

        if (amigoSelecionado == null)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"O empréstimo \"{idAmigo}\" não foi encontrado!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Presione ENTER para continuar");
            Console.ReadLine();
            return;
        }
        if (revistaSelecionada == null)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"A revista \"{idRevista}\" não foi encontrado!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Presione ENTER para continuar");
            Console.ReadLine();
            return;
        }
        if (!revistaSelecionada.EstaDisponivel)
        {
            if (revistaSelecionada == null)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"A revista \"{idRevista}\" está indisponível!");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Presione ENTER para continuar");
                Console.ReadLine();
                return;
            }
        }

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

            if (e.Amigo.Id == amigoSelecionado.Id && e.EstaAberto)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"O amigo \"{amigoSelecionado.Nome}\" possui empréstimo em aberto!");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Presione ENTER para continuar");
                Console.ReadLine();
            }
        }

        Emprestimo novoEmprestimo = new Emprestimo(amigoSelecionado, revistaSelecionada);

        novoEmprestimo.Abrir();

        repositorioEmprestimo.Cadastrar(novoEmprestimo);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O empréstimo \"{novoEmprestimo.Id}\" foi aberto com sucesso!");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Presione ENTER para continuar");
        Console.ReadLine();

    }

    public void Concluir()
    {
        Console.WriteLine("---------------------------");
        Console.WriteLine("Conclusão de Empréstimos");
        Console.WriteLine("---------------------------");

        VisualizarTodos(false);

        Console.WriteLine("---------------------------");
        Console.Write("Digite o ID do empréstimo que deseja concluir: ");
        int idEmprestimo = Convert.ToInt32(Console.ReadLine());

        Emprestimo? emprestimo = (Emprestimo?)repositorioEmprestimo.SelecionarPorId(idEmprestimo);

        if (emprestimo == null)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"O empréstimo \"{idEmprestimo}\" não foi encontrado!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Presione ENTER para continuar");
            Console.ReadLine();
            return;
        }

        if (!emprestimo.EstaAberto)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"O empréstimo \"{idEmprestimo}\" já está concluído!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Presione ENTER para continuar");
            Console.ReadLine();
            return;

        }

        emprestimo.Concluir();

        repositorioEmprestimo.Editar(idEmprestimo, emprestimo);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O empréstimo \"{emprestimo.Id}\" foi concluído com sucesso!");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Presione ENTER para continuar");
        Console.ReadLine();
    }

    public void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Visualização de Empréstimos");
            Console.WriteLine("---------------------------");
        }

        Console.WriteLine(
          "{0, -7} | {1, -15} | {2, -15} | {3, -12} | {4, -15} | {5, -13}",
          "Id", "Revista", "Amigo", "Abertura", "Conclusão Prev.", "Status"
          );

        EntidadeBase[] emprestimos = repositorioEmprestimo.SelecionarTodos();

        for (int i = 0; i < emprestimos.Length; i++)
        {
            Emprestimo e = (Emprestimo)emprestimos[i];

            if (e == null)
                continue;

            Console.WriteLine(
          "{0, -7} | {1, -15} | {2, -15} | {3, -12} | {4, -15} | {5, -13}",
          e.Id, e.Revista.Titulo, e.Amigo.Nome, e.DataAbertura.ToShortDateString(), e.DataConclusaoPrevista.ToShortDateString(), e.Status.ToString()
          );

        }

        if (deveExibirCabecalho)
        {

            Console.WriteLine("---------------------------");
            Console.WriteLine("Pressione ENTER para prosseguir.");
            Console.ReadLine();
        }
    }

    private void VisualizarRevistas()
    {
        Console.WriteLine(
           "{0, -7} | {1, -25} | {2, -6} | {3, -4} | {4, -15} | {5, -12}",
           "Id", "Título", "Edição", "Ano", "Caixa", "Status"
       );

        EntidadeBase[] revistas = repositorioRevista.SelecionarTodos();

        for (int i = 0; i < revistas.Length; i++)
        {
            Revista r = (Revista)revistas[i];

            if (r == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -25} | {2, -6} | {3, -4} | {4, -15}",
                r.Id, r.Titulo, r.NumeroEdicao, r.AnoPublicacao, r.Caixa.Etiqueta, r.Status.ToString()
            );
        }
    }
    private void VisualizarAmigos()
    {
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
    }

}
