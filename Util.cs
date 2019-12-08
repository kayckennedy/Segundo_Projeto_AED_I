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
        LerArquivo ler_todo_log = new LerArquivo("_infos\\log.txt");
        string [] log = ler_todo_log.LerTodasAsLinhas();
        
        for(int i = 0; i < log.Length; i ++){
            Console.WriteLine(log[i]);
        }
        
    }
    public static void LimparLog(){
        GravarArquivo limpeza_log = new GravarArquivo("_infos\\log.txt");
        
        Console.WriteLine("Tem certeza que deseja apagar todo o log ? [S/n]: ");
        bool apagar_tudo = Console.ReadLine() == "s" ? true : false;
        
        if(apagar_tudo){ 
            limpeza_log.LimparArquivo();
            Console.WriteLine("Log apagado com sucesso");
            
            Console.WriteLine("\nVoltando ao menu anterior...");
            
        }
        if(apagar_tudo == false) {
            Console.WriteLine("Voltando ao menu anterior...");
            
        }
        else {
            Console.WriteLine("Escolha invalida");
            Console.WriteLine("Voltando ao menu anterior...");
            
        }
        Util.LimparTela();

        Util.TecleEnterParaSair();
    }

}