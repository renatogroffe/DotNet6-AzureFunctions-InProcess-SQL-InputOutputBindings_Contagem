namespace FunctionAppContagem.Contagem;

public class DadosContador
{
    public int ValorAtual { get; set; }
    public string Instancia { get; set; }
    public string Kernel { get; set; }
    public string Framework { get; set; }
    public string Mensagem { get; set; }
}

public class ResultadoContador
{
    public int Id { get; set; }
    public int ValorAtual { get; set; }
    public string Instancia { get; set; }
    public string Kernel { get; set; }
    public string Framework { get; set; }
    public string Mensagem { get; set; }
}