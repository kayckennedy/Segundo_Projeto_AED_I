using System.IO;
using System.Text;

class GravarArquivo {

    private string arquivo_caminho;

    public GravarArquivo(string arquivo_caminho) {
        this.arquivo_caminho = arquivo_caminho;
    }

    public void GravarUmaLinha(string texto) {
        try {
            // Se o caminho do arquivo existir, o texto será gravado
            FileStream gravar_linha_stream = new FileStream(this.arquivo_caminho, FileMode.Open, FileAccess.Write);
            StreamWriter gravar_linha_writer = new StreamWriter(gravar_linha_stream, Encoding.UTF8);

            gravar_linha_writer.WriteLine(texto);

            gravar_linha_writer.Close();
            gravar_linha_stream.Close();
        } catch {
            // Caso der erro, o arquivo será criado usando o caminho que foi passado
            StreamWriter gravar_linha_writer = File.CreateText(arquivo_caminho);
            
            gravar_linha_writer.WriteLine(texto);
            
            gravar_linha_writer.Close();
        }
    }

    public void GravarContinuamente(string texto) {
        File.AppendAllText(this.arquivo_caminho, texto + "\n");
    }

    public void LimparArquivo() {
        System.IO.File.WriteAllText(this.arquivo_caminho, string.Empty);
    }

    public void ApagarUmaLinha(string texto_procurado) {
        LerArquivo todos_os_registros = new LerArquivo(this.arquivo_caminho);

        string[] vetor_registros = todos_os_registros.LerTodasAsLinhas();

        LimparArquivo();

        foreach (string linha in vetor_registros) {
            if (linha != texto_procurado) {
                GravarContinuamente(linha);
            }
        }
    }

}