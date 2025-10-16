namespace AppWeb.Models
{
    public class Notificacao
    {
        public int Id { get; set; }
        public string? NumeroPedido { get; set; }
        public string? NomeCliente { get; set; }
        public string? Status { get; set; }
        public decimal? Total { get; set; }

    }
}