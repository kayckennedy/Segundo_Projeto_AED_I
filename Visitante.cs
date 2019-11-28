class Visitante : Pessoa {

    public Visitante(string nome_completo, string cpf, Data data_nascimento, string email, string senha) {
        this.nome_completo = nome_completo;
        this.cpf = cpf;
        this.data_nascimento = data_nascimento;
        this.email = email;
        this.senha = senha;
    }

    public void SalvarCadastroNoArquivo() {
        GravarArquivo gravar_arquivo = new GravarArquivo("_arquivos\\_logins\\logins_visitante.txt");

        string dados_completo = this.nome_completo + ";";
        dados_completo += this.cpf + ";";
        dados_completo += this.data_nascimento.GetDataCompleta() + ";";
        dados_completo += this.email + ";";
        dados_completo += this.senha;

        gravar_arquivo.GravarContinuamente(dados_completo);
    }

    public bool VerificarSeCadastroExiste() {
        LerArquivo arquivo_dados = new LerArquivo("_arquivos\\_logins\\logins_visitante.txt");

        string[] dados_cadastrais = arquivo_dados.LerTodasAsLinhas();

        bool cadastro_existe = false;

        foreach (string linha in dados_cadastrais) {
            string[] dados_separados = linha.Split(";");

            if (this.cpf == dados_separados[1] || this.email == dados_separados[3]) {
                cadastro_existe = true;
                break;
            }
        }

        return cadastro_existe;
    }

}