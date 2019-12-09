using System;

class Program {
    static void Main(string[] args) {
        try {
            Util.LimparTela();

            int escolha_menu_principal;
            do {
                Util.GravarLog("Programa iniciado, Usuario: Desconhecido");

                Console.WriteLine("*============================================*");
                Console.WriteLine("*= Olá!!");
                Console.WriteLine("*= Escolha UMA dentre as opções disponíveis =*");
                Console.WriteLine("*============================================*");
                Console.WriteLine("*= 1 - Fazer Login");
                Console.WriteLine("*= 2 - Criar Cadastro de Visitante");
                Console.WriteLine("*= 3 - Recuperar Conta");
                Console.WriteLine("*= 0 - Fechar Programa");
                Console.WriteLine("*============================================*");

                Console.Write("*= Escolha uma das opções acima: ");
                escolha_menu_principal = int.Parse(Console.ReadLine());

                Util.LimparTela();
                switch (escolha_menu_principal) {
                    case 1: // FAZER LOGIN
                        Console.Write("\nVocê é um administrador ou visitante? [V/a]: ");
                        bool login_admin = Console.ReadLine().ToLower() == "a" ? true : false;

                        Util.LimparTela();

                        Console.Write("Insira o email cadastrado: ");
                        string email_cadastrado = Console.ReadLine();

                        Console.Write("Insira a senha: ");
                        string senha_cadastrada = Console.ReadLine();

                        Util.LimparTela();

                        Login usuario = new Login(email_cadastrado, senha_cadastrada, login_admin);

                        if (usuario.VerificarInformacoesParaLogin()) {

                            string[] informacoes_do_usuario_logado = usuario.PegarInformacoesDepoisDeAutenticado();
                            if (login_admin) {
                                Administrador admin = new Administrador(informacoes_do_usuario_logado[0], informacoes_do_usuario_logado[1], new Data(informacoes_do_usuario_logado[2]), informacoes_do_usuario_logado[3], informacoes_do_usuario_logado[4], informacoes_do_usuario_logado[5]);

                                Util.GravarLog("O usuário " + admin.GetNomeCompleto() + ", acabou de fazer login");

                                int escolha_menu_administrador = 0;
                                do {
                                    Console.WriteLine("\n*===========================================*");
                                    Console.WriteLine("*= Escolha UMA entre as opções disponíveis =*");
                                    Console.WriteLine("*= Olá, {0}!!", admin.GetNomeCompleto());
                                    Console.WriteLine("*===========================================*");
                                    Console.WriteLine("*= 1 - Listar Visitas Marcadas");
                                    Console.WriteLine("*= 2 - Apagar uma Visita Marcada");
                                    Console.WriteLine("*= 3 - Apagar TODAS as Visitas");
                                    Console.WriteLine("*= 4 - Cadastrar Artista");
                                    Console.WriteLine("*= 5 - Apagar um Artista");
                                    Console.WriteLine("*= 6 - Apagar TODOS os Artistas");
                                    Console.WriteLine("*= 7 - Cadastrar Obra");
                                    Console.WriteLine("*= 8 - Apagar uma Obra");
                                    Console.WriteLine("*= 9 - Apagar TODAS as Obras");
                                    Console.WriteLine("*= 10 - Listar Sugestões Salvas");
                                    Console.WriteLine("*= 11 - Apagar uma Sugestão");
                                    Console.WriteLine("*= 12 - Apagar todas as sugestões");
                                    Console.WriteLine("*= 13 - Cadastrar novo Admin");
                                    Console.WriteLine("*= 14 - Vizualizar log");
                                    Console.WriteLine("*= 15 - Apagar Log's");
                                    Console.WriteLine("*= 0 - Voltar à Tela de Login");
                                    Console.WriteLine("*===========================================*");

                                    Console.Write("*= Escolha uma das opções acima: ");
                                    escolha_menu_administrador = int.Parse(Console.ReadLine());

                                    switch (escolha_menu_administrador) {
                                        case 1:
                                            Visitas.LerTodasAsVisitas();
                                            Util.GravarLog("Listar todas as visitas, usuario que realizou: " + admin.GetNomeCompleto());
                                        break;
                                        case 2:
                                            Visitas.ApagarUmaVisita();
                                        break;
                                        case 3:
                                            Visitas.ApagarTodasAsVisitas();
                                            Util.GravarLog("Apagar todas as visitas, usuario que realizou: " + admin.GetNomeCompleto());
                                        break;
                                        case 4:
                                            Artista.CadastrarArtista();
                                        break;
                                        case 5:
                                            Artista.ApagarUmArtista();
                                        break;
                                        case 6:
                                            Artista.ApagarTodosOsArtista();
                                            Util.GravarLog("Apagar todos os artistas, usuario que realizou: " + admin.GetNomeCompleto());
                                        break;
                                        case 7:
                                            Obra.CadastrarObra();
                                        break;
                                        case 8:
                                            Obra.ApagarUmaObra();
                                        break;
                                        case 9:
                                            Obra.ApagarTodasAsObras();
                                        break;
                                        case 10:
                                            Visitas.ListarSugestoes();
                                        
                                        break;
                                        case 11:
                                            Visitas.ApagarUmaSugestao();
                                        break;
                                        case 12:
                                            Visitas.ApagarTodasAsSugestoes();
                                            Util.GravarLog("Todas as sugestões foram apagadas, usuario que realizou: " + admin.GetNomeCompleto());
                                        break;
                                        case 13:
                                            Login.FazerCadastro(true);
                                        break;
                                        case 14:
                                            Util.LerLog();
                                        break;
                                        case 15:
                                            Util.LimparLog();
                                            Util.GravarLog("Log apagado, usuário que realizou: " + admin.GetNomeCompleto());
                                        break;
                                        case 0:
                                            Util.LimparTela();
                                            Util.GravarLog("O usuário " + admin.GetNomeCompleto() + " fez log out");
                                            
                                            Console.WriteLine("Voltando...");

                                            Util.TecleEnterParaSair();
                                        break;
                                        default:
                                            Util.LimparTela();

                                            Console.WriteLine("Escolha inválida");
                                        break;
                                    }
                                } while (escolha_menu_administrador != 0);
                            } else {
                                Visitante visitante = new Visitante(informacoes_do_usuario_logado[0], informacoes_do_usuario_logado[1], new Data(informacoes_do_usuario_logado[2]), informacoes_do_usuario_logado[3], informacoes_do_usuario_logado[4]);

                                int escolha_menu_visitante = 0;
                                do {
                                    Console.WriteLine("\n*===========================================*");
                                    Console.WriteLine("*= Escolha UMA entre as opções disponíveis =*");
                                    Console.WriteLine("*= Olá, {0}!!", visitante.GetNomeCompleto());
                                    Console.WriteLine("*===========================================*");
                                    Console.WriteLine("*= 1 - Agendar Visita");
                                    Console.WriteLine("*= 2 - Deixar Sugestão");
                                    Console.WriteLine("*= 3 - Listar Artistas");
                                    Console.WriteLine("*= 4 - Listar Obras");
                                    Console.WriteLine("*= 5 - Ver informações Sobre o Museu");
                                    Console.WriteLine("*= 0 - Voltar à Tela de Login");
                                    Console.WriteLine("*===========================================*");

                                    Console.Write("*= Escolha uma das opções acima: ");
                                    escolha_menu_visitante = int.Parse(Console.ReadLine());
                                    Util.GravarLog(visitante.GetNomeCompleto() + " entrou no sistema");

                                    switch (escolha_menu_visitante) {
                                        case 1:
                                            Visitas.AgendarVisita(visitante);
                                        break;
                                        case 2:
                                            Visitas.DeixarSugestao(visitante);
                                        break;
                                        case 3:
                                            Artista.ListarArtistas();
                                        break;
                                        case 4:
                                            Obra.ListarObras();
                                        break;
                                        case 5:
                                            Museu informacoes = new Museu();
                                            informacoes.InformacoesMuseu();
                                            Util.GravarLog("Visualização das informações do Museu, usuário " + visitante.GetNomeCompleto());
                                        break;
                                        case 0:
                                            Util.LimparTela();

                                            Console.WriteLine("Voltando...");
                                            Util.GravarLog("O usuário " + visitante.GetNomeCompleto() + " fez log out");

                                            Util.TecleEnterParaSair();
                                        break;
                                        default:
                                            Util.LimparTela();

                                            Console.WriteLine("Escolha inválida");
                                        break;
                                    }
                                } while (escolha_menu_visitante != 0);
                            }
                        } else {
                            Util.LimparTela();

                            Console.WriteLine("E-mail ou Senha inválidos!");
                            Console.WriteLine("Tente novamente..");

                            Util.Pausa(5000);

                            Util.LimparTela();
                        }
                    break;
                    case 2: // CRIAR CADASTRO
                        Login.FazerCadastro(false);
                    break;
                    case 3:
                        Login.RecuperarContaVisitante();
                    break;
                    case 0: // SAIR DO APP
                        Util.LimparTela();

                        Console.WriteLine("Saindo...");
                        Console.WriteLine("Volte sempre!!");
                        
                        Util.TecleEnterParaSair();
                    break;
                    default: // ESCOLHA INVÁLIDA
                        Console.WriteLine("Escolha inválida");
                        Util.Pausa(5000);
                    break;
                }
            } while(escolha_menu_principal != 0);
        } catch {
            Util.LimparTela();

            Console.WriteLine("Apenas números inteiros são aceitos.\nTente novamente...");

            Util.Pausa(5000);
        }

    }
}
