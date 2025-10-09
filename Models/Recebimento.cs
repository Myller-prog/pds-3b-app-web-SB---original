namespace AppWeb.Models
{
    public class Recebimento
    {
        public int Id { get; set; }
        public string? Pedido { get; set; }
        public decimal? Valor { get; set; }
        public string? FormaPagamentoRec { get; set; }
        public string? Comprovante { get; set; }
        public string? ClienteRec { get; set; }
        
    }
}
