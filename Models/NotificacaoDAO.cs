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
                notificacao.Id = leitor.GetInt32("id_noti");
                notificacao.NumeroPedido = leitor.GetDecimal("numero_pedido_noti");
                notificacao.NomeClientePed = DAOHelper.GetString(leitor, "nome_cliente_noti");
                notificacao.StatusPed = DAOHelper.GetString(leitor, "status_noti");


                lista.Add(notificacao);
            }

            return lista;
        }

        public void Inserir(Notificacao notificacao)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO notificacao VALUES (@_numeroPedido, @_nomeCliente, @_status, @_total)");

                comando.Parameters.AddWithValue("@_numeroPedido", notificacao.NumeroPedido);
                comando.Parameters.AddWithValue("@_nomeCliente", notificacao.NomeClientePed);
                comando.Parameters.AddWithValue("@_status", notificacao.StatusPed);
                comando.Parameters.AddWithValue("@_total", notificacao.TotalPed);


                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}