using System;
class Museu {
    private string nome;
    private Data data_inauguracao;
    private string ceo_atual;
   

    public Museu(){
    }

    public void SetCeoAtual(string ceo_atual){
        GravarArquivo setCeo = new GravarArquivo("_infos\\info_museu\\nome_presidente.txt");
        this.ceo_atual = ceo_atual;
        setCeo.GravarUmaLinha(ceo_atual);
    }
    public string GetCeoAtual(){
        LerArquivo getCeo = new LerArquivo("_infos\\info_museu\\nome_presidente.txt");
        return getCeo.LerLinha();
    }
    public void SetNomeMuseu(string nome){
        GravarArquivo setNome = new GravarArquivo("_infos\\info_museu\\nome_museu.txt");
        setNome.GravarUmaLinha(nome);
    }
    public string GetnomeMuseu(){
        LerArquivo getNome = new LerArquivo("_infos\\info_museu\\nome_museu.txt");
        return getNome.LerLinha();    
        }
}