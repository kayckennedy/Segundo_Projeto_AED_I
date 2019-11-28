using System;

class Controlador {

    public static void FazerCadastro(bool cadastro_administrador) {
        bool refazer_cadastro = false;
        string nome_completo, cpf, email, cargo = "", senha_conferida = "";
        Data data_nascimento;

        do {
            Console.Write("Insira o nome completo: ");
            nome_completo = Console.ReadLine();
            Console.Write("Digite o CPF: ");
            cpf = Console.ReadLine();
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
            Console.Write("Deseja verificar seu cadastro? [S/n]: ");
            string escolha_revisar_cadastro = Console.ReadLine();
            if (escolha_revisar_cadastro.ToLower() == "s") {
                Console.WriteLine("Nome completo: " + nome_completo);
                Console.WriteLine("CPF: " + cpf);
                Console.WriteLine("Data de nascimento: " + data_nascimento.GetDataCompleta());
                Console.WriteLine("E-mail: " + email);

                // SE FOR CADASTRO DE UM ADMINISTRADOR
                if (cadastro_administrador == true) {
                    Console.WriteLine("Cargo: " + cargo);
                }

                // REFAZER CADASTRO
                Console.WriteLine("Deseja refazer seu cadastro? [S/n]: ");
                refazer_cadastro = Console.ReadLine().ToLower() == "s" ? true : false;
            }
        } while (refazer_cadastro);
        
        if (cadastro_administrador == true) { // SE FOR CADASTRO DE UM ADMINISTRADOR
            Administrador novo_cadastro_administrador = new Administrador(nome_completo, cpf, data_nascimento, email, senha_conferida, cargo);
            
            if (novo_cadastro_administrador.VerificarSeCadastroExiste()) {
                Console.WriteLine("E-mail ou CPF do visitante já cadastrados!");
            } else {
                novo_cadastro_administrador.SalvarCadastroNoArquivo();
                Console.WriteLine("Cadastro realizado com sucesso, visitante!\nJá pode fazer seu login!");
            }
        } else { // SE FOR CADASTRO DE UM VISITANTE
            Visitante novo_cadastro_visitante = new Visitante(nome_completo, cpf, data_nascimento, email, senha_conferida);
            
            if (novo_cadastro_visitante.VerificarSeCadastroExiste()) {
                Console.WriteLine("E-mail ou CPF já cadastrados!");
            } else {
                novo_cadastro_visitante.SalvarCadastroNoArquivo();
                Console.WriteLine("Cadastro realizado com sucesso!");
            }
        }
    }

}