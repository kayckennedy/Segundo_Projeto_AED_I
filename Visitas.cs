using System;

class Visitas : Data {

    private int hora_entrada;
    private int minuto_entrada;
    private int hora_saida;
    private int minuto_saida;

    public int GetHorarioEntrada() {
        return hora_entrada;
    }

    public Visitas(string horario_entrada, string horario_saida, string data_completa) {
        string[] horario_inicial = new string[2];
        horario_inicial = horario_entrada.Split(":");

        string[] horario_final = new string[2];
        horario_final = horario_saida.Split(":");

        this.hora_entrada = int.Parse(horario_inicial[0]);
        this.minuto_entrada = int.Parse(horario_inicial[1]);
        this.hora_saida = int.Parse(horario_final[0]);
        this.minuto_saida = int.Parse(horario_final[1]);

        SetDataCompleta(data_completa);
    }

    private bool VerificarHorario() {
        if ((this.hora_entrada >= 8 && this.hora_entrada <= 17) && (this.minuto_entrada >= 0 && this.minuto_saida <= 59) && (this.hora_saida >= this.hora_entrada && this.hora_saida <= 17) && (this.minuto_saida >= 0 && this.minuto_saida <= 59)) {
            return true;
        }

        return false;
    }

    public string GravarVisita(Visitante visitante) {
        if (VerificarDiaMes() && VerificarHorario()) {
            string texto_formatado_para_gravar;

            string hora_ini = this.hora_entrada >= 0 && this.hora_entrada <= 9 ? "0" + this.hora_entrada.ToString() : this.hora_entrada.ToString();
            string minu_ini = this.minuto_entrada >= 0 && this.minuto_entrada <= 9 ? "0" + this.minuto_entrada.ToString() : this.minuto_entrada.ToString();
            string hora_fin = this.hora_saida >= 0 && this.hora_saida <= 9 ? "0" + this.hora_saida.ToString() : this.hora_saida.ToString();
            string minu_fin = this.minuto_saida >= 0 && this.minuto_saida <= 9 ? "0" + this.minuto_saida.ToString() : this.minuto_saida.ToString();

            texto_formatado_para_gravar = "Nome: " + visitante.GetNomeCompleto() + ". Data marcada: " + GetDataCompleta() + ". Hora da Entrada: " + hora_ini + ":" + minu_ini + ". Hora Saída: " + hora_fin + ":" + minu_ini + ".";

            GravarArquivo gravar_visita = new GravarArquivo("_infos\\visitas_agendadas.txt");
            gravar_visita.GravarContinuamente(texto_formatado_para_gravar);
            
            Util.GravarLog("Visita agendada: " + texto_formatado_para_gravar);
            return "Agendado com sucesso!\n\nFoi armazenado o seguinte registro...\n" + texto_formatado_para_gravar;
            
        }

        return "Não foi possível fazer o agendamento...\n\nPor favor, verifique os dados e tente novamente.";
    }

    public static void AgendarVisita(Visitante visitante) {
        Util.LimparTela();

        Console.Write("\nInsira o horário de entrada no seguinte formato [HH:MM]: ");
        string horario_entrada = Console.ReadLine();
        Console.Write("Insira também, o horário de saída no seguinte horário [HH:MM]: ");
        string horario_saida = Console.ReadLine();
        Console.Write("Agora digite a data da visita no seguinte formato [DD/MM/AAAA]: ");
        string data_completa = Console.ReadLine();

        Util.LimparTela();

        Visitas visitas = new Visitas(horario_entrada, horario_saida, data_completa);

        Console.WriteLine("\n" + visitas.GravarVisita(visitante));
        

        Util.TecleEnterParaSair();
    }

    public static void ApagarUmaVisita() {
        Util.LimparTela();

        LerArquivo ler_registros = new LerArquivo("_infos\\visitas_agendadas.txt");

        string[] visitas_marcadas = ler_registros.LerTodasAsLinhas();

        for (int i = 0; i < visitas_marcadas.Length; i++) {
            Console.WriteLine("{0} - {1}", i + 1, visitas_marcadas[i]);
        }
        Console.Write("\nEscolha a visita a ser apagada: ");
        int visita_escolha = int.Parse(Console.ReadLine()) - 1;

        GravarArquivo apagar_visita = new GravarArquivo("_infos\\visitas_agendadas.txt");
        apagar_visita.ApagarUmaLinha(visitas_marcadas[visita_escolha]);
        Util.GravarLog("Visita apagada: " + visitas_marcadas[visita_escolha]);

        Util.LimparTela();

        Console.WriteLine("Visita apagada com sucesso!");
        
        Util.TecleEnterParaSair();
    }

    public static void ApagarTodasAsVisitas() {
        GravarArquivo apagar_tudo = new GravarArquivo("_infos\\visitas_agendadas.txt");

        Util.LimparTela();

        Console.WriteLine("Tem certeza que deseja apagar todas as visitas? [S/n]: ");
        bool escolha_apagar_tudo = Console.ReadLine() == "s" ? true : false;

        if (escolha_apagar_tudo) {
            apagar_tudo.LimparArquivo();

            Console.WriteLine("Todas as visitas foram apagadas com sucesso!");
           
        } else {
            Console.WriteLine("Nenhum registro foi apagado.");
        }
        
        Util.LimparTela();

        Util.TecleEnterParaSair();
    }

    public static void LerTodasAsVisitas() {
        LerArquivo ler_visitas = new LerArquivo("_infos\\visitas_agendadas.txt");

        foreach (string visita_completa in ler_visitas.LerTodasAsLinhas()) {
            Console.WriteLine(visita_completa);
        }

        Console.WriteLine("Todas as visitas agendadas");

        Util.TecleEnterParaSair();
    }

    public static void DeixarSugestao(Visitante visitante) {
        Util.LimparTela();

        Console.Write("Digite o sua sugestão: ");
        string sugestao_completa = "O visitante, " + visitante.GetNomeCompleto() + ". Deixou a seguinte sugestão: " + Console.ReadLine();

        GravarArquivo gravar_sugestao = new GravarArquivo("_infos\\sugestoes.txt");
        gravar_sugestao.GravarContinuamente(sugestao_completa);

        Util.LimparTela();

        Console.WriteLine("Sua sugestão foi armazenada, e em breve a analisaremos!");
        Util.GravarLog("Sugestão registrada: " + sugestao_completa);
        
        Util.TecleEnterParaSair();
    }

    public static void ListarSugestoes() {
        LerArquivo ler_sugestoes = new LerArquivo("_infos\\sugestoes.txt");

        Util.LimparTela();

        foreach (string sugestao in ler_sugestoes.LerTodasAsLinhas()) {
            Console.WriteLine(sugestao);
        }
         Util.GravarLog("Listar todas as sugestões");
        Util.TecleEnterParaSair();
    }

    public static void ApagarUmaSugestao() {
        Util.LimparTela();

        LerArquivo ler_registros = new LerArquivo("_infos\\sugestoes.txt");

        string[] sugestoes_salvas = ler_registros.LerTodasAsLinhas();

        for (int i = 0; i < sugestoes_salvas.Length; i++) {
            Console.WriteLine("{0} - {1}", i + 1, sugestoes_salvas[i]);
        }
        Console.Write("\nEscolha a sugestão a ser apagada: ");
        int sugestao__escolha = int.Parse(Console.ReadLine()) - 1;

        GravarArquivo apagar_sugestao = new GravarArquivo("_infos\\visitas_agendadas.txt");
        apagar_sugestao.ApagarUmaLinha(sugestoes_salvas[sugestao__escolha]);
        Util.GravarLog("Sugestão apagada: " + sugestoes_salvas[sugestao__escolha]);

        Util.LimparTela();

        Console.WriteLine("Sugestão apagada com sucesso!");
        Util.GravarLog("Sugestão apagada: " + sugestoes_salvas[sugestao__escolha]);

        Util.TecleEnterParaSair();
    }

    public static void ApagarTodasAsSugestoes() {
        GravarArquivo apagar_tudo = new GravarArquivo("_infos\\sugestoes.txt");

        Util.LimparTela();

        Console.WriteLine("Tem certeza que deseja apagar todas as sugestões? [S/n]: ");
        bool escolha_apagar_tudo = Console.ReadLine() == "s" ? true : false;

        if (escolha_apagar_tudo) {
            apagar_tudo.LimparArquivo();

            Console.WriteLine("Todas as sugestões foram apagadas com sucesso!");
           
        } else {
            Console.WriteLine("Nenhum registro foi apagado.");
        }

        Util.LimparTela();

        Util.TecleEnterParaSair();
    }

}