using System.ComponentModel.DataAnnotations;

namespace AppWeb.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "Nome muito longo.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O cargo é obrigatório.")]
        public string Cargo { get; set; }

        // Se DataNasc for string
        public string DataNasc { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Cep { get; set; }
    }
}
