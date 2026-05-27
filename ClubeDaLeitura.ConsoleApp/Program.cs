using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa);
TelaPrincipal telaPrincipal = new TelaPrincipal();

while (true)
{
    string? opcaoMenuPrincipal = telaPrincipal.ObterOpcaoMenuPrincipal();

    if (opcaoMenuPrincipal == "S")
    {
        break;
    }

    while (true)
    {
        if (opcaoMenuPrincipal == "1")
        {
            string? opcaoMenuInterno = telaCaixa.ObterOpcaoMenu();

            if (opcaoMenuInterno == "S")
                break;

            if (opcaoMenuInterno == "1")
                telaCaixa.Cadastar();

            else if (opcaoMenuInterno == "2")
                telaCaixa.Editar();

            else if (opcaoMenuInterno == "3")
                telaCaixa.Excluir();

            else if (opcaoMenuInterno == "4")
                telaCaixa.VisualizarTodos(true);

        }


    }
}