using System;

class Artista {

    private string nome_completo;
    private Data data_nascimento;
    private string[] campos_de_trabalho;
    private Obra[] obras_de_arte;
    private int qtd_campos;

    public Artista(string nome_completo, Data data_nascimento, string[] campos_de_trabalho, int qtd_campos){
        this.nome_completo = nome_completo;
        this.data_nascimento = data_nascimento;
        this.campos_de_trabalho = campos_de_trabalho;
        this.qtd_campos = qtd_campos;
    }

    public Artista() {
        this.nome_completo = "Artista Anônimo";
        this.data_nascimento = new Data();
        this.campos_de_trabalho = new string[1] {"Desconhecido"};
    }

    public string GetNome() {
        return this.nome_completo;
    }
    
    // Método que retorna a data de nascimento do artista
    public Data GetDataNascimento() {
        return this.data_nascimento;
    }

    // Método retornando os campos nos quais o artista trabalha
    public string[] GetCampos() {
        return this.campos_de_trabalho;
    }

    public int GetQtdCampos(){
        return qtd_campos;
    }

    public void GravarInformacoes() {
        GravarArquivo gravar_nome = new GravarArquivo("_infos\\info_artista\\nome.txt");
        gravar_nome.GravarContinuamente(this.nome_completo);

        GravarArquivo gravar_data_nascimento = new GravarArquivo("_infos\\info_artista\\data_nascimento.txt");
        gravar_data_nascimento.GravarContinuamente(this.data_nascimento.GetDataCompleta());

        GravarArquivo gravar_campos = new GravarArquivo("_infos\\info_artista\\campos.txt");
        string campos_completo = "";

        for (int i = 0; i < this.campos_de_trabalho.Length; i++) {
            if (i == this.campos_de_trabalho.Length - 1) {
                campos_completo += this.campos_de_trabalho[i];
            } else {
                campos_completo += this.campos_de_trabalho[i] + ";";
            }
        }
        
        gravar_campos.GravarContinuamente(campos_completo);
    }

    public static string[] LerTodosOsNomes() {
        LerArquivo ler_nomes = new LerArquivo("_infos\\info_artista\\nome.txt");
        return ler_nomes.LerTodasAsLinhas();
    }

    public static string[] LerTodasAsDatasDeNascimentos() {
        LerArquivo ler_datas = new LerArquivo("_infos\\info_artista\\data_nascimento.txt");
        return ler_datas.LerTodasAsLinhas();
    }

    public static string[] LerTodosOsCampos() {
        LerArquivo ler_campos = new LerArquivo("_infos\\info_artista\\campos.txt");
        return ler_campos.LerTodasAsLinhas();
    }

    public static void CadastrarArtista() {
        Util.LimparTela();

        Console.Write("Nome completo do artista: ");
        string nome_completo = Console.ReadLine();
        
        Console.Write("Sua data de nascimento: ");
        Data data_nascimento = new Data(Console.ReadLine());
        
        Console.Write("Em quantos campos diferentes ele atua? [Ex: Pintura e Arquitetura = 2]: ");
        int qtd_campos_de_trabalho = int.Parse(Console.ReadLine());
        
        string[] campos_de_trabalho = new string[qtd_campos_de_trabalho];
        
        for (int i = 0; i < qtd_campos_de_trabalho; i++) {
            Console.Write("Digite o {0}º campo: ", i + 1);
            campos_de_trabalho[i] = Console.ReadLine();
        }
        
        Artista novo_cadastro = new Artista(nome_completo, data_nascimento, campos_de_trabalho, qtd_campos_de_trabalho);
        novo_cadastro.GravarInformacoes();

        Console.WriteLine("Artista cadastrado com sucesso!");
        
        Util.GravarLog("Artista cadastrado: " + nome_completo);


        Util.TecleEnterParaSair();
    }

    public static void ApagarUmArtista() {
        string[] nomes_artistas = Artista.LerTodosOsNomes();
        string[] datas_nascimentos_artistas = Artista.LerTodasAsDatasDeNascimentos();
        string[] campos_artistas = Artista.LerTodosOsCampos();

        for (int i = 0; i < nomes_artistas.Length; i++) {
            Console.WriteLine("{0} - {1}", i + 1, nomes_artistas[i]);
        }
        Console.Write("Escolha o artista a ser apagado: ");
        int artista_escolha = int.Parse(Console.ReadLine()) - 1;

        GravarArquivo apagar_nomes = new GravarArquivo("_infos\\info_artista\\nome.txt");
        apagar_nomes.ApagarUmaLinha(nomes_artistas[artista_escolha]);
        Util.GravarLog("Artista apagado: " + nomes_artistas[artista_escolha]);

        GravarArquivo apagar_datas_nascimentos = new GravarArquivo("_infos\\info_artista\\data_nascimento.txt");
        apagar_datas_nascimentos.ApagarUmaLinha(datas_nascimentos_artistas[artista_escolha]);

        GravarArquivo apagar_campos = new GravarArquivo("_infos\\info_artista\\campos.txt");
        apagar_campos.ApagarUmaLinha(campos_artistas[artista_escolha]);

        Console.WriteLine("Artista apagado com sucesso!");

        Util.TecleEnterParaSair();
    }

    public static void ApagarTodosOsArtista() {
        GravarArquivo apagar_todos_campos = new GravarArquivo("_infos\\info_artista\\campos.txt");
        GravarArquivo apagar_todas_datas_nasc = new GravarArquivo("_infos\\info_artista\\data_nascimento.txt");
        GravarArquivo apagar_todos_nomes = new GravarArquivo("_infos\\info_artista\\nome.txt");
        

        Util.LimparTela();

        Console.WriteLine("Tem certeza que deseja apagar todos os artistas? [S/n]: ");
        bool escolha_apagar_tudo = Console.ReadLine() == "s" ? true : false;

        if (escolha_apagar_tudo) {
            apagar_todos_campos.LimparArquivo();
            apagar_todas_datas_nasc.LimparArquivo();
            apagar_todos_nomes.LimparArquivo();

            Console.WriteLine("Todos os artistas foram apagados com sucesso!");

        } else {
            Console.WriteLine("Nenhum registro foi apagado.");
        }

        Util.LimparTela();

        Util.TecleEnterParaSair();
    }

    public static void ListarArtistas() {
        Util.LimparTela();

        string[] todos_os_nomes = Artista.LerTodosOsNomes();
        string[] todas_as_datas_de_nascimento = Artista.LerTodasAsDatasDeNascimentos();
        string[] todos_os_campos = Artista.LerTodosOsCampos();

        Artista[] todos_os_artistas = new Artista[todos_os_nomes.Length];

        for (int i = 0; i < todos_os_artistas.Length; i++) {
            todos_os_artistas[i] = new Artista(todos_os_nomes[i], new Data(todas_as_datas_de_nascimento[i]), todos_os_campos[i].Split(";"), todos_os_campos[i].Split(";").Length);
        }

        int contador = 1;
        foreach (Artista artista in todos_os_artistas) {
            Console.WriteLine("{0}º artista: {1}", contador, artista.GetNome());
            Console.WriteLine("Data de Nascimento: {0}", artista.GetDataNascimento());
            
            Console.Write("Campos de atuação: // ");
            foreach (string campo in artista.GetCampos()) {
                Console.Write(campo + " // ");
            }

            contador++;
            Console.WriteLine("\n");
        }
        Util.GravarLog("Artistas listados");
        Util.TecleEnterParaSair();
    }
    
}