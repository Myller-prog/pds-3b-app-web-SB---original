namespace AppWeb.Models
{
    public class GestaoRecebimento
    {
        public int Id { get; set; }
        public string? Pedido { get; set; }
        public string? Valor { get; set; }
        public string? FormaPagamento { get; set; }
        public string? Comprovante { get; set; }
        public string? Cliente { get; set; }
        
    }
}
