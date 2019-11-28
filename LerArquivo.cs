using System.IO;
using System.Text;

class LerArquivo {

    private string arquivo_caminho;

    public LerArquivo(string arquivo_caminho) {
        this.arquivo_caminho = arquivo_caminho;
    }

    public string LerLinha() {
        FileStream ler_arquivo_stream = new FileStream(this.arquivo_caminho, FileMode.Open, FileAccess.Read);
        StreamReader ler_arquivo_reader = new StreamReader(ler_arquivo_stream, Encoding.UTF8);

        string linha_lida;

        if (ObterQtdLinha() == 0) {
            linha_lida = "SEM VALOR SALVO NO ARQUIVO \"" + this.arquivo_caminho + "\"";
        } else {
            linha_lida = ler_arquivo_reader.ReadLine();
        }

        ler_arquivo_reader.Close();
        ler_arquivo_stream.Close();

        return linha_lida;
    }

    public string[] LerTodasAsLinhas() {
        FileStream ler_arquivo_stream = new FileStream(this.arquivo_caminho, FileMode.Open, FileAccess.Read);
        StreamReader ler_arquivo_reader = new StreamReader(ler_arquivo_stream, Encoding.UTF8);

        int qtd_linhas = ObterQtdLinha();

        string[] dados_lidos;

        if (qtd_linhas == 0) {
            dados_lidos = new string[1];
            dados_lidos[0] = "SEM VALOR SALVO NO ARQUIVO \"" + this.arquivo_caminho + "\"";
        } else {
            dados_lidos = new string[qtd_linhas];

            for (int i = 0; i < qtd_linhas; i++) {
                dados_lidos[i] = ler_arquivo_reader.ReadLine();
            }
        }
        
        ler_arquivo_reader.Close();
        ler_arquivo_stream.Close();

        return dados_lidos;
    }

    public int ObterQtdLinha() {
        FileStream ler_arquivo_stream = new FileStream(this.arquivo_caminho, FileMode.Open, FileAccess.Read);
        StreamReader ler_arquivo_reader = new StreamReader(ler_arquivo_stream, Encoding.UTF8);

        int qtd_linhas = 0;

        while (!ler_arquivo_reader.EndOfStream) {
            ler_arquivo_reader.ReadLine();
            qtd_linhas += 1;
        }

        ler_arquivo_reader.Close();
        ler_arquivo_stream.Close();

        return qtd_linhas;
    }

}