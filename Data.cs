class Data{
    protected int dia;
    protected int mes;
    protected int ano;
    protected int[] indice_dias_no_mes = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
    public string teste;
    public bool data_validada = false;

    public Data() {
        this.dia = 0;
        this.mes = 0;
        this.ano = 0;
    }    
 

    public Data(string data_completa){

      SetData_completa(data_completa);
    }

    public void SetData_completa(string data_completa){
        string[] data_quebrada = new string[3];
        data_quebrada = data_completa.Split("/");

        int dia = int.Parse(data_quebrada[0]);
        int mes = int.Parse(data_quebrada[1]);
        int ano = int.Parse(data_quebrada[2]);
        
        VerificarBissexto(ano);

         if (VerificarData(dia, mes)) {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
            this.data_validada = true;
        } else { // Caso não seja validado
            this.dia = 0;
            this.mes = 0;
            this.ano = 0;
        }
    }


    private void VerificarBissexto(int ano) {
        if ((ano % 400 == 0) || (ano % 4 == 0 && ano % 100 != 0)) {
            this.indice_dias_no_mes[1] = 29;
        }
    }
    public bool VerificarData(int dia, int mes) {
        if ((mes >= 1 && mes <= 12) && (dia >= 1 && dia <= this.indice_dias_no_mes[mes - 1])) {
            return true;
        }
        return false;
    }
    public string GetDataCompleta() {
        string s_dia;
        string s_mes;
        string s_ano;

        if (this.dia >= 0 && this.dia <= 9) {
            s_dia = "0" + this.dia.ToString();
        } else {
            s_dia = this.dia.ToString();
        }

        if (this.mes >= 0 && this.mes <= 9) {
            s_mes = "0" + this.mes.ToString();
        } else {
            s_mes = this.mes.ToString();
        }

        if (this.ano == 0) {
            s_ano = "0000";
        } else {
            s_ano = this.ano.ToString();
        }

        return s_dia + "/" + s_mes + "/" + s_ano;
    }
}