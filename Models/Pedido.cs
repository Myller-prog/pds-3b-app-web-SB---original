namespace AppWeb.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string? NomeCliente { get; set; }
        public string? FormaPagamento { get; set; }

        public string? Status { get; set; }


        public string? NumeroPedido { get; set; }

        public decimal Total { get; set; }

    }
}

