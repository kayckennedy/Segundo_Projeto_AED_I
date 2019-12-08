using System;

class Login {

    private string login_email;
    private string senha;
    private bool login_admin;

    public Login(string login_email, string senha, bool login_admin) {
        this.login_email = login_email;
        this.senha = senha;
        this.login_admin = login_admin;
    }

    public bool VerificarInformacoesParaLogin() {
        bool usuario_autenticado = false;
        LerArquivo ler_informacoes_para_login;

        if (login_admin) {
            ler_informacoes_para_login = new LerArquivo("_infos\\_logins\\logins_admin.txt");
        } else {
            ler_informacoes_para_login = new LerArquivo("_infos\\_logins\\logins_visitante.txt");
        }

        foreach (string linha_completa in ler_informacoes_para_login.LerTodasAsLinhas()) {
            if (linha_completa.Split(";")[3] == this.login_email && linha_completa.Split(";")[4] == this.senha) {
                usuario_autenticado = true;
            }
        }

        return usuario_autenticado;
    }

    public string[] PegarInformacoesDepoisDeAutenticado() {
        LerArquivo ler_dados_do_usuario_logado;

        if (login_admin) {
            ler_dados_do_usuario_logado = new LerArquivo("_infos\\_logins\\logins_admin.txt");
        } else {
            ler_dados_do_usuario_logado = new LerArquivo("_infos\\_logins\\logins_visitante.txt");
        }

        foreach (string informacoes_completa in ler_dados_do_usuario_logado.LerTodasAsLinhas()) {
            if (informacoes_completa.Split(";")[3] == this.login_email && informacoes_completa.Split(";")[4] == this.senha) {
                return informacoes_completa.Split(";");
            }
        }

        return null;
    }

    public static void FazerCadastro(bool cadastro_administrador) {
        bool refazer_cadastro = false;
        string nome_completo, cpf, email, cargo = "", senha_conferida = "";
        Data data_nascimento;

        do {
            Util.LimparTela();
            Console.WriteLine("*===========================================*");
            Console.Write("Insira o nome completo: ");
            nome_completo = Console.ReadLine();

            bool cpf_valido = false;
            do {
                Console.Write("Digite o CPF: ");
                cpf = Console.ReadLine();

                if (Util.VerificadorDeCpf(cpf)) {
                    cpf_valido = true;
                }
                else {
                    Console.WriteLine("\nCPF inválido...\nTente novamente\n");
                }
            } while(!cpf_valido);
            
            Console.Write("Agora nos informe a data de nascimento no seguinte formato [DD/MM/AAAA]: ");
            data_nascimento = new Data(Console.ReadLine());
            Console.Write("Por favor, digite o e-mail: ");
            email = Console.ReadLine();

            // SE FOR CADASTRO DE UM ADMINISTRADOR
            if (cadastro_administrador == true) {
                Console.Write("Por favor, digite o cargo: ");
                cargo = Console.ReadLine();
            }

            // VERIFICAÇÃO DA SENHA
            bool senha_valida = false;
            do {
                Console.Write("Digite sua senha: ");
                string senha_1 = Console.ReadLine();
                Console.Write("Repita a senha: ");
                string senha_2 = Console.ReadLine();

                if (senha_1 == senha_2) {
                    senha_conferida = senha_1;
                    senha_valida = true;
                } else {
                    Console.WriteLine("Senhas não conferem. Repita o processo.");
                }
            } while (!senha_valida);

            // CONFIRMAR CADASTRO
            Console.Write("\nDeseja verificar seu cadastro? [S/n]: ");
            if (Console.ReadLine().ToLower() == "s") {
                Util.LimparTela();
                Console.WriteLine("Nome completo: " + nome_completo);
                Console.WriteLine("CPF: " + cpf);
                Console.WriteLine("Data de nascimento: " + data_nascimento.GetDataCompleta());
                Console.WriteLine("E-mail: " + email);

                // SE FOR CADASTRO DE UM ADMINISTRADOR
                if (cadastro_administrador == true) {
                    Console.WriteLine("Cargo: " + cargo);
                }

                // REFAZER CADASTRO
                Console.Write("\nDeseja recomeçar o cadastro? [S/n]: ");
                refazer_cadastro = Console.ReadLine().ToLower() == "s" ? true : false;
            }
        } while (refazer_cadastro);
        
        Util.LimparTela();

        if (cadastro_administrador == true) { // SE FOR CADASTRO DE UM ADMINISTRADOR
            Administrador novo_cadastro_administrador = new Administrador(nome_completo, cpf, data_nascimento, email, senha_conferida, cargo);
            
            if (novo_cadastro_administrador.VerificarSeCadastroExiste()) {
                Console.WriteLine("\nE-mail ou CPF já cadastrados!");
            } else {
                novo_cadastro_administrador.SalvarCadastroNoArquivo();

                Console.WriteLine("\nCadastro realizado com sucesso!");
                Util.GravarLog("Novo administrador cadastrado: " + nome_completo + ", cargo: "  + cargo);
            }
        } else { // SE FOR CADASTRO DE UM VISITANTE
            Visitante novo_cadastro_visitante = new Visitante(nome_completo, cpf, data_nascimento, email, senha_conferida);
            
            if (novo_cadastro_visitante.VerificarSeCadastroExiste()) {
                Console.WriteLine("\nE-mail ou CPF de visitante já cadastrados!");
            } else {
                novo_cadastro_visitante.SalvarCadastroNoArquivo();

                Console.WriteLine("\nCadastro realizado com sucesso, visitante!");
                Util.GravarLog("Novo visitante cadastrado: " + nome_completo);
                Console.WriteLine("Já pode fazer seu login!");
            }
        }

        Console.WriteLine("Voltando ao menu principal...");

        Util.Pausa(5000);

        Util.LimparTela();
    }

    public static void RecuperarContaVisitante() {
        Util.LimparTela();

        Console.WriteLine("Para recuperar sua conta, precisamos do email e do CPF cadastrado...");

        Console.Write("Por favor, digite o e-mail cadastrado: ");
        string email_recuperar = Console.ReadLine();

        Console.Write("Por favor, digite o CPF cadastrado: ");
        string cpf_recuperar = Console.ReadLine();

        LerArquivo ler_informacoes_recuperar = new LerArquivo("_infos\\_logins\\logins_visitante.txt");
        string[] todos_os_cadastros = ler_informacoes_recuperar.LerTodasAsLinhas();

        string salvar_nome = "", salvar_cpf = "", salvar_data_nascimento = "", salvar_email = "";

        bool informacoes_encontradas = false;

        foreach (string linha in todos_os_cadastros) {
            string[] informacoes_separadas = linha.Split(";");

            if (informacoes_separadas[1] == cpf_recuperar && informacoes_separadas[3] == email_recuperar) {
                informacoes_encontradas = true;

                salvar_nome = informacoes_separadas[0];
                salvar_cpf = informacoes_separadas[1];
                salvar_data_nascimento = informacoes_separadas[2];
                salvar_email = informacoes_separadas[3];

                GravarArquivo apagar_registro = new GravarArquivo("_infos\\_logins\\logins_visitante.txt");
                apagar_registro.ApagarUmaLinha(linha);

                break;
            }
        }

        if (informacoes_encontradas) {
            bool senha_valida = false;

            string senha_conferida = "";

            do {
                Console.Write("\nDigite sua nova senha: ");
                string senha_1 = Console.ReadLine();
                Console.Write("Repita a senha: ");
                string senha_2 = Console.ReadLine();

                if (senha_1 == senha_2) {
                    senha_conferida = senha_1;
                    senha_valida = true;
                } else {
                    Console.WriteLine("Senhas não conferem. Repita o processo.");
                    Util.Pausa(5000);
                    Util.LimparTela();
                }
            } while (!senha_valida);

            Visitante recadastrar_visitante = new Visitante(salvar_nome, salvar_cpf, new Data(salvar_data_nascimento), salvar_email, senha_conferida);
            recadastrar_visitante.SalvarCadastroNoArquivo();

            Console.WriteLine("Troca de senha realizada com sucesso!");
            Util.GravarLog("Senha do usuário " + salvar_nome + " redefinda");
            Util.TecleEnterParaSair();
        } else {
            Util.LimparTela();

            Console.WriteLine("Cadastro não encontrado...");

            Util.TecleEnterParaSair();
        }
    }

}