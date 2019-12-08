class Pessoa {

    protected string nome_completo;
    protected string cpf;
    protected Data data_nascimento;
    protected string email;
    protected string senha;

    public string GetNomeCompleto() {
        return this.nome_completo;
    }

    public string GetCpf() {
        return this.cpf;
    }

    public Data GetDataNascimento() {
        return this.data_nascimento;
    }

    public string GetEmail() {
        return this.email;
    }

    public string GetSenhaLogin() {
        return this.senha;
    }

    public void SetNomeCompleto(string nome_completo) {
        this.nome_completo = nome_completo;
    }

    public void SetCpf(string cpf) {
        this.cpf = cpf;
    }

    public void SetDataNascimento(Data data_nascimento) {
        this.data_nascimento = data_nascimento;
    }

    public void SetEmail(string email) {
        this.email = email;
    }
    
    public void SetSenha(string senha) {
        this.senha = senha;
    }
    
}