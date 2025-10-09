using AppWeb.Configs;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace AppWeb.Models
{
    public class RecebimentoDAO
    {
        private readonly Conexao _conexao;
        public RecebimentoDAO(Conexao conexao) // serve pra fornecedor também
        {
            _conexao = conexao;
        }

        public List<Recebimento> listarTodos()
        {
            var lista = new List<Recebimento>();

            var comando = _conexao.CreateCommand("SELECT * FROM recebimento;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read()) // enquanto tiver condição, o while vai rodar
            {
                var recebimento = new Recebimento();
                recebimento.Id = leitor.GetInt32("id_receb");
                recebimento.Pedido = DAOHelper.GetString(leitor, "pedido_receb");
                recebimento.Valor = leitor.GetDecimal("valor_receb");
                recebimento.FormaPagamentoRec = DAOHelper.GetString(leitor, "formaPag_receb");
                recebimento.Comprovante = DAOHelper.GetString(leitor, "comprovante_receb");
                recebimento.ClienteRec = DAOHelper.GetString(leitor, "cliente_receb");


                lista.Add(recebimento);
            }

            return lista;
        }

        public void Inserir(Recebimento recebimento)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO recebimento VALUES (@_pedido, @_valor, @_formaPagamento, @_comprovante, @_cliente)");

                comando.Parameters.AddWithValue("@_pedido", recebimento.Pedido);
                comando.Parameters.AddWithValue("@_valor", recebimento.Valor);
                comando.Parameters.AddWithValue("@_formaPagamento", recebimento.FormaPagamentoRec);
                comando.Parameters.AddWithValue("@_comprovante", recebimento.Comprovante);
                comando.Parameters.AddWithValue("@_cliente", recebimento.ClienteRec);


                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
