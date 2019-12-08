using System;

class Obra {

    private string titulo;
    private string artista;
    private int ano_criacao;
    private string descricao;

    public Obra(string titulo, string artista, int ano_criacao, string descricao) {
        this.titulo = titulo;
        this.artista = artista;
        this.ano_criacao = ano_criacao;
        this.descricao = descricao;
    }

    public string GetTitulo() {
        return this.titulo;
    }

    // Método para retornar o nome do artista criador
    public string GetArtista() {
        return this.artista;
    }

    // Método para retornar o ano de criacao
    public int GetAnoCriacao() {
        return this.ano_criacao;
    }

    // Método para retornar a descricao da obra
    public string GetDescricao() {
        return this.descricao;
    }

    public static string[] LerTodosOsTitulos() {
        LerArquivo ler_obras = new LerArquivo("_infos\\info_obra\\nome.txt");
        return ler_obras.LerTodasAsLinhas();
    }

    // Método estático para pegar o nome do criador de cada obra
    public static string[] LerTodosOsArtistas() {
        LerArquivo ler_artistas = new LerArquivo("_infos\\info_obra\\nome_artista.txt");
        return ler_artistas.LerTodasAsLinhas();
    }

    // Método estático para pegar o ano de criação das obras
    public static string[] LerTodosAnosDeCriacao() {
        LerArquivo ler_ano_criacao = new LerArquivo("_infos\\info_obra\\ano_criacao.txt");
        return ler_ano_criacao.LerTodasAsLinhas();
    }

    // Método estático para ler todas as descrições
    public static string[] LerTodasAsDescricoes() {
        LerArquivo ler_descricoes = new LerArquivo("_infos\\info_obra\\descricao.txt");
        return ler_descricoes.LerTodasAsLinhas();
    }

    public void ArmazenarInformacoes() {
        GravarArquivo gravar_nome = new GravarArquivo("_infos\\info_obra\\nome.txt");
        gravar_nome.GravarContinuamente(this.titulo);

        GravarArquivo gravar_nome_artista = new GravarArquivo("_infos\\info_obra\\nome_artista.txt");
        gravar_nome_artista.GravarContinuamente(this.artista);

        GravarArquivo gravar_ano_criacao = new GravarArquivo("_infos\\info_obra\\ano_criacao.txt");
        gravar_ano_criacao.GravarContinuamente(this.ano_criacao.ToString());

        GravarArquivo gravar_descricao = new GravarArquivo("_infos\\info_obra\\descricao.txt");
        gravar_descricao.GravarContinuamente(this.descricao);
    }

    public static void CadastrarObra() {
        Util.LimparTela();

        Console.Write("Qual o título da obra? ");
        string titulo_obra = Console.ReadLine();

        Console.Write("Insira uma descrição para a obra: ");
        string descricao_obra = Console.ReadLine();

        Console.Write("Qual o ano de criação da obra? ");
        int ano_criacao_obra = int.Parse(Console.ReadLine());

        string nome_artista;
        string[] todos_os_nomes_de_artistas_cadastrados = Artista.LerTodosOsNomes();

        Console.WriteLine();

        for (int i = 0; i < todos_os_nomes_de_artistas_cadastrados.Length; i++) {
            Console.WriteLine("{0} - {1}", i + 1, todos_os_nomes_de_artistas_cadastrados[i]);
        }
        Console.WriteLine("0 - Anônimo");
        Console.Write("Escolha uma das opções acima: ");
        int escolha_nome_artista = int.Parse(Console.ReadLine());

        if (escolha_nome_artista == 0) {
            nome_artista = "Anônimo";
        } else {
            nome_artista = todos_os_nomes_de_artistas_cadastrados[escolha_nome_artista - 1];
        }

        Obra nova_obra = new Obra(titulo_obra, nome_artista, ano_criacao_obra, descricao_obra);
        nova_obra.ArmazenarInformacoes();

        Console.WriteLine("\nObra cadastrada com sucesso!");
        Util.GravarLog("Obra cadastrada, titulo: " + titulo_obra + ", Data de criação: " + ano_criacao_obra);

        Util.TecleEnterParaSair();
    }

    public static void ApagarUmaObra() {
        string[] titulos_obras = Obra.LerTodosOsTitulos();
        string[] anos_de_criacao_obras = Obra.LerTodosAnosDeCriacao();
        string[] descricoes_obras = Obra.LerTodasAsDescricoes();
        string[] nomes_artistas = Obra.LerTodosOsArtistas();

        int obra_escolha = 0;
        do {
            Util.LimparTela();
            
            for (int i = 0; i < titulos_obras.Length; i++) {
                Console.WriteLine("{0} - {1}", i + 1, titulos_obras[i]);
            }
            Console.WriteLine("0 - Cancelar");
            Console.Write("Escolha a obra a ser apagada: ");
            obra_escolha = int.Parse(Console.ReadLine());

            if (obra_escolha != 0) {
                try {
                    GravarArquivo apagar_titulos = new GravarArquivo("_infos\\info_obra\\nome.txt");
                    apagar_titulos.ApagarUmaLinha(titulos_obras[obra_escolha - 1]);

                    GravarArquivo apagar_anos_de_criacao = new GravarArquivo("_infos\\info_obra\\ano_criacao.txt");
                    apagar_anos_de_criacao.ApagarUmaLinha(anos_de_criacao_obras[obra_escolha - 1]);

                    GravarArquivo apagar_descricoes = new GravarArquivo("_infos\\info_obra\\descricao.txt");
                    apagar_descricoes.ApagarUmaLinha(descricoes_obras[obra_escolha - 1]);

                    GravarArquivo apagar_nome_artista = new GravarArquivo("_infos\\info_obra\\nome_artista.txt");
                    apagar_nome_artista.ApagarUmaLinha(nomes_artistas[obra_escolha - 1]);

                    Util.LimparTela();

                    Console.WriteLine("Obra apagada com sucesso!");
                    Util.GravarLog("Obra apagada: " + titulos_obras[obra_escolha - 1]);

                    Util.TecleEnterParaSair();
                } catch {
                    Util.LimparTela();

                    Console.WriteLine("Erro!");

                    Util.TecleEnterParaSair();
                }
            } else {
                Console.WriteLine("Escolha indisponível");
            }

        } while(obra_escolha != 0);
    }

    public static void ListarObras() {
        Util.LimparTela();

        string[] titulos_obras = Obra.LerTodosOsTitulos();
        string[] descricoes_obras = Obra.LerTodasAsDescricoes();
        string[] nomes_artistas_obras = Obra.LerTodosOsArtistas();
        string[] anos_criacao_obras = Obra.LerTodosAnosDeCriacao();

        for (int i = 0; i < titulos_obras.Length; i++) {
            Console.WriteLine("Título da Obra: {0}", titulos_obras[i]);
            Console.WriteLine("Descrição: {0}", descricoes_obras[i]);
            Console.WriteLine("Criada em {0}, por {1}", anos_criacao_obras[i], nomes_artistas_obras[i]);
            Console.WriteLine();
        }
        Util.GravarLog("Obras listadas");
        Util.TecleEnterParaSair();
    }

    public static void ApagarTodasAsObras() {
        Util.LimparTela();

        Console.Write("Deseja realmente APAGAR TODAS as obras? [S/n]: ");
        if (Console.ReadLine().ToLower() == "s") {
            GravarArquivo apagar_todos_anos = new GravarArquivo("_infos\\info_obra\\ano_criacao.txt");
            GravarArquivo apagar_todas_descricoes = new GravarArquivo("_infos\\info_obra\\descricao.txt");
            GravarArquivo apagar_todos_nomes_artistas = new GravarArquivo("_infos\\info_obra\\nome_artista.txt");
            GravarArquivo apagar_todos_nomes = new GravarArquivo("_infos\\info_obra\\nome.txt");

            apagar_todos_anos.LimparArquivo();
            apagar_todas_descricoes.LimparArquivo();
            apagar_todos_nomes_artistas.LimparArquivo();
            apagar_todos_nomes.LimparArquivo();

            Util.LimparTela();

            Console.WriteLine("\nTodas as obras foram APAGADAS!!!");
            Util.GravarLog("Todas as obras foram apagadas");

            Util.TecleEnterParaSair();
        } else {
            Util.LimparTela();

            Console.WriteLine("\nNenhuma obra foi apagada...");
            Console.WriteLine("Voltando ao Menu...");

            Util.TecleEnterParaSair();
        }        
    }
}