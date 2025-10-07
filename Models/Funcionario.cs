namespace AppWeb.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string Cargo { get; set; }
        public string DataNasc { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public int? Cep { get; set; }
        public int? Cpf { get; set; }
    }
}
