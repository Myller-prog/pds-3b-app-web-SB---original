namespace AppWeb.Models
{
    public class Notificacao
    {
        public int Id { get; set; }
        public string? NumeroPedido { get; set; }
        public string? NomeClientePed { get; set; }
        public string? StatusPed { get; set; }
        public decimal? TotalPed { get; set; }

    }
}