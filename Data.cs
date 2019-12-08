class Data {

    protected int dia;
    protected int mes;
    protected int ano;
    protected int[] indice_dias_no_mes = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
    public bool data_validada = false;

    public Data() {
        this.dia = 0;
        this.mes = 0;
        this.ano = 0;
    }

    public Data(string data_completa){
        SetDataCompleta(data_completa);
    }

    public void SetDataCompleta(string data_completa){
        string[] data_quebrada = data_completa.Split("/");

        this.dia = int.Parse(data_quebrada[0]);
        this.mes = int.Parse(data_quebrada[1]);
        this.ano = int.Parse(data_quebrada[2]);
        
        SetFevereiroSeBissexto();
    }

    private void SetFevereiroSeBissexto() {
        if ((this.ano % 400 == 0) || (this.ano % 4 == 0 && this.ano % 100 != 0)) {
            this.indice_dias_no_mes[1] = 29;
        }
    }

    public bool VerificarDiaMes() {
        if ((this.mes >= 1 && this.mes <= 12) && (this.dia >= 1 && this.dia <= this.indice_dias_no_mes[this.mes - 1])) {
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