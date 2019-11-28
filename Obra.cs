class Obra{
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
    
    public Obra(string titulo, int ano_criacao, string descricao) {
        this.titulo = titulo;
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
        return ler_obras.LerTodas();
    }
    // Método estático para pegar o nome do criador de cada obra
    public static string[] LerTodosOsArtistas() {
        LerArquivo ler_artistas = new LerArquivo("_infos\\info_obra\\nome_artista.txt");
        return ler_artistas.LerTodas();
    }
    // Método estático para pegar o ano de criação das obras
    public static string[] LerTodosAnosDeCriacao() {
        LerArquivo ler_ano_criacao = new LerArquivo("_infos\\info_obra\\ano_criacao.txt");
        return ler_ano_criacao.LerTodas();
    }
    // Método estático para ler todas as descrições
    public static string[] LerTodasAsDescricoes() {
        LerArquivo ler_descricoes = new LerArquivo("_infos\\info_obra\\descricao.txt");
        return ler_descricoes.LerTodas();
    } 

    public void ArmazenarInformacoes() {
        GravarArquivo gravar_nome = new GravarArquivo("_infos\\info_obra\\nome.txt");
        gravar_nome.GravarAppend(this.titulo);

        GravarArquivo gravar_nome_artista = new GravarArquivo("_infos\\info_obra\\nome_artista.txt");
        gravar_nome_artista.GravarAppend(this.artista);

        GravarArquivo gravar_ano_criacao = new GravarArquivo("_infos\\info_obra\\ano_criacao.txt");
        gravar_ano_criacao.GravarAppend(this.ano_criacao.ToString());

        GravarArquivo gravar_descricao = new GravarArquivo("_infos\\info_obra\\descricao.txt");
        gravar_descricao.GravarAppend(this.descricao);
    }
}