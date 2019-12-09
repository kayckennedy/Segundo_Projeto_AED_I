using System;
class Museu {

    private string nome;
    private string ceo_atual;

    public Museu() {
        this.nome = GetNomeMuseu();
        this.ceo_atual = GetCeoAtual();
    }

    public void SetCeoAtual(string ceo_atual) {
        GravarArquivo setCeo = new GravarArquivo("_infos\\info_museu\\nome_presidente.txt");
        setCeo.GravarUmaLinha(ceo_atual);
    }

    public string GetCeoAtual() {
        LerArquivo getCeo = new LerArquivo("_infos\\info_museu\\nome_presidente.txt");
        return getCeo.LerLinha();
    }

    public void SetNomeMuseu(string nome) {
        GravarArquivo setNome = new GravarArquivo("_infos\\info_museu\\nome_museu.txt");
        setNome.GravarUmaLinha(nome);
    }

    public string GetNomeMuseu() {
        LerArquivo getNome = new LerArquivo("_infos\\info_museu\\nome_museu.txt");
        return getNome.LerLinha();    
    }

    public void InformacoesMuseu() {
        LerArquivo qtd_obra = new LerArquivo("_infos\\info_obra\\nome.txt");

        Util.LimparTela();
        
        Console.WriteLine("Bem vindo ao Museu " + this.nome);
        Console.WriteLine("Atualmente, nosso presidente é o " + this.ceo_atual);
        Console.WriteLine("Contamos com cerca de " +  qtd_obra.ObterQtdLinha() + " obras");

        Util.TecleEnterParaSair();
    }
}