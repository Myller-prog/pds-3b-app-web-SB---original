using AppWeb.Configs;

namespace AppWeb.Models
{
    public class NotificacaoDAO
    {
        private readonly Conexao _conexao;
        public NotificacaoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }


        public List<Notificacao> listarTodos()
        {
            var lista = new List<Notificacao>();

            var comando = _conexao.CreateCommand("SELECT * FROM notificacao;");
            var leitor = comando.ExecuteReader();


            while (leitor.Read())
            {
                var notificacao = new Notificacao();
                notificacao .Id = leitor.GetInt32("id_noti");
                notificacao.NumeroPedido = DAOHelper.GetString(leitor, "numero_pedido_noti");
                notificacao.NomeCliente = DAOHelper.GetString(leitor, "nome_cliente_noti");
                notificacao.Status = DAOHelper.GetString(leitor, "status_noti");
                comando.Parameters.AddWithValue("@_total_noti", notificacao.Total);


                lista.Add(notificacao);
            }

            return lista;
        }

        public void Inserir(Notificacao notificacao)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO cliente VALUES (@_nome, @_telefone, @_email, @_cidade, @_estado)");

                comando.Parameters.AddWithValue("@_numeroPedido", notificacao .NumeroPedido);
                comando.Parameters.AddWithValue("@_nomeCliente", notificacao .NomeCliente);
                comando.Parameters.AddWithValue("@_status", notificacao .Status);
                comando.Parameters.AddWithValue("@_total", notificacao .Total);
               

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
