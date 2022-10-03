namespace src.Models;

public class Contrato
{
    public Contrato()
    {
        this.DataCriacao = DateTime.Now;
        this.Valor = 0;
        this.TokenId = "000000";
    }
    public Contrato(string TokenId, double Valor)
    {
        this.DataCriacao = DateTime.Now;
        this.TokenId = TokenId;
        this.Valor = Valor;
    }
    public DateTime DataCriacao { get; set;  }
    public string TokenId { get; set; }
    public double Valor { get; set; }
    public int Id { get; set; } // Chave primaria
    public int PessoaId { get; set; } // Chave extrangeira
}