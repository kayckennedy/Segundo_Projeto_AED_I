class Artista{
    private string nome_completo;
    private Data data_nascimento;
    private string[] campos_de_trabalho;
    private Obra obras_de_arte;
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
        gravar_nome.GravarAppend(this.nome_completo
        );

        GravarArquivo gravar_data_nascimento = new GravarArquivo("_infos\\info_artista\\data_nascimento.txt");
        gravar_data_nascimento.GravarAppend(this.data_nascimento.GetDataCompleta());

        GravarArquivo gravar_campos = new GravarArquivo("_infos\\info_artista\\campos.txt");
        string campos_completo = "";

        for (int i = 0; i < this.campos_de_trabalho.Length; i++) {
            campos_completo += ";" + this.campos_de_trabalho[i];
        }
        gravar_campos.GravarAppend(campos_completo);
    }

    public static string[] LerTodosOsNomes() {
        LerArquivo ler_nomes = new LerArquivo("_infos\\info_artista\\nome.txt");
        return ler_nomes.LerTodas();
    }
    public static string[] LerTodasAsDatasDeNascimentos() {
        LerArquivo ler_datas = new LerArquivo("_infos\\info_artista\\data_nascimento.txt");
        return ler_datas.LerTodas();
    }
    public static string[] LerTodosOsCampos() {
        LerArquivo ler_campos = new LerArquivo("_infos\\info_artista\\campos.txt");
        return ler_campos.LerTodas();
    }
    
}