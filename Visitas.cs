class Visitas : Data{
  private string nome_visitante;
  private int hora_entrada;
  private int minuto_entrada;
  private int hora_saida;
  private int minuto_saida;

  public string GetNome_visitante(){
    return nome_visitante;
  }
  public int Gethorario_entrada(){
    return hora_entrada;
  }
  
  private bool horario_valido = false;

  public Visitas(string horario_entrada, string horario_saida, string data_completa){

    string[] horario_inicial = new string[2];
    horario_inicial = horario_entrada.Split(":");

    string[] horario_final = new string[2];
    horario_final = horario_saida.Split(":");

    this.hora_entrada = int.Parse(horario_inicial[0]);
    this.minuto_entrada = int.Parse(horario_inicial[1]);
    this.hora_saida = int.Parse(horario_final[0]);
    this.minuto_saida = int.Parse(horario_final[1]);

    SetData_completa(data_completa);
    VerificarHorario();
  }

  private bool VerificarHorario(){

    if ((this.hora_entrada >= 8 && this.hora_entrada <= 17) && (this.minuto_entrada >= 0 && this.minuto_saida <= 59) && (this.hora_saida >= this.hora_entrada && this.hora_saida <= 17) && (this.minuto_saida >= 0 && this.minuto_saida <= 59)) {
       this.horario_valido = true;
    } else {
        this.horario_valido = false;
    }
    return horario_valido;

  }
    public string GravarVisita(){
      
      if (VerificarData(dia, mes) && this.horario_valido) {


        string texto_formatado_para_gravar;

          texto_formatado_para_gravar = "Nome: " + this.nome_visitante + ". Data: " + GetDataCompleta() + ". Hora da Entrada: " + this.hora_entrada + ":" + this.minuto_saida + ". Hora Saída: " + this.hora_saida + ":" + this.minuto_saida + ".";

          GravarArquivo gravar_visita = new GravarArquivo("_infos\\agenda.txt");
          gravar_visita.GravarAppend(texto_formatado_para_gravar);

          return "\nAgendado com sucesso!\nFoi armazenado o seguinte registro...\n" + texto_formatado_para_gravar;
        }
        return "\nNão foi possível fazer o agendamento...\nPor favor, verifique os dados e tente novamente.";
  }

}