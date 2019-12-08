using System;
using System.Threading;

class Util {
    
    public static void LimparTela() {
        Console.Clear();
    }

    public static void Pausa(int milisegundos) {
        Thread.Sleep(milisegundos);
    }

    public static void VoltarParaTelaDeLogin() {
        Util.LimparTela();

        Console.WriteLine("Voltando à Tela de Login...");

        Util.Pausa(3000);
        
        Util.LimparTela();
    }
    
    public static void GravarLog(string acao) {
        GravarArquivo log = new GravarArquivo("_infos\\log.txt");
        string data_hora_alteracao = DateTime.Now.ToShortTimeString() + " - " + DateTime.Now.ToShortDateString();
        
        log.GravarContinuamente("Ação Realizada: " + acao + ", Dia e Hora: " + data_hora_alteracao);
    }

    public static void TecleEnterParaSair() {
        Console.Write("\nAperte ENTER para sair...");
        Console.ReadLine();

        LimparTela();
    }

    public static void LerLog(){
        LimparTela();

        LerArquivo ler_todo_log = new LerArquivo("_infos\\log.txt");
        string [] log = ler_todo_log.LerTodasAsLinhas();
        
        for(int i = 0; i < log.Length; i ++){
            Console.WriteLine(log[i]);
        }

        TecleEnterParaSair();
    }

    public static void LimparLog(){
        LimparTela();

        try {
            Console.Write("Tem certeza que deseja apagar todo o log ? [S/n]: ");
            bool apagar_tudo = Console.ReadLine() == "s" ? true : false;

            GravarArquivo limpeza_log = new GravarArquivo("_infos\\log.txt");
            
            if (apagar_tudo) {
                limpeza_log.LimparArquivo();
                Console.WriteLine("Log apagado com sucesso");
                
                Console.WriteLine("\nVoltando ao menu anterior...");
                
            } else {
                Console.WriteLine("Voltando ao menu anterior...");
            }
        } catch {
            Console.WriteLine("Escolha invalida");
            Console.WriteLine("Voltando ao menu anterior...");
        }
        
        Util.TecleEnterParaSair();
    }

    public static bool VerificadorDeCpf(string cpf) {
        try {
            string cpf_completo = cpf;

            char[] cpf_quebrado_verificador = cpf_completo.ToCharArray(0, cpf_completo.Length);

            int pesos = 10, somatorio = 0;
            for (int indice = 0; indice < 9; indice++) {
                somatorio += int.Parse(cpf_quebrado_verificador[indice].ToString()) * pesos;
                pesos--;
            }

            int primeiro_digito_verificador;

            if (somatorio % 11 < 2) {
                primeiro_digito_verificador = 0;
            } else {
                primeiro_digito_verificador = 11 - (somatorio % 11);
            }

            cpf_quebrado_verificador[9] = Convert.ToChar(primeiro_digito_verificador.ToString());

            pesos = 11;
            somatorio = 0;
            for (int indice = 0; indice < 10; indice++) {
                somatorio += int.Parse(cpf_quebrado_verificador[indice].ToString()) * pesos;
                pesos--;
            }

            int segundo_digito_verificador;

            if (somatorio % 11 < 2) {
                segundo_digito_verificador = 0;
            } else {
                segundo_digito_verificador = 11 - (somatorio % 11);
            }

            cpf_quebrado_verificador[10] = Convert.ToChar(segundo_digito_verificador.ToString());

            char[] cpf_quebrado_digitado = cpf_completo.ToCharArray(0, cpf_completo.Length);

            bool cpf_valido = true;
            for (int indice = 0; indice < 11; indice++) {
                if (cpf_quebrado_verificador[indice] != cpf_quebrado_digitado[indice]) {
                    cpf_valido = false;
                }
            }

            return cpf_valido;
        } catch {
            return false;
        }
    }

}