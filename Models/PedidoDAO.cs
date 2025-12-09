using AppWeb.Configs;
using System.Data;

namespace AppWeb.Models
{
    public class PedidoDAO
    {
        private readonly Conexao _conexao;
        public PedidoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }


        public List<Pedido> listarTodos()
        {
            var lista = new List<Pedido>();

            // Use 'using' para garantir que o comando seja descartado
            using (var comando = _conexao.CreateCommand("SELECT * FROM pedido;"))
            {
                // Use 'using' para garantir que o leitor seja fechado
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        var pedido = new Pedido();
                        pedido.Id = leitor.GetInt32("id_ped");
                        pedido.Status = leitor.GetString("status_ped");
                        pedido.NomeCliente = DAOHelper.GetString(leitor, "NomeCliente"); // Verifique o nome da coluna 'NomeCliente'
                        pedido.FormaPagamento = DAOHelper.GetString(leitor, "forma_pagamento");
                        pedido.NumeroPedido = DAOHelper.GetString(leitor, "numero_pedido");
                        pedido.Total = leitor.GetDecimal("total");

                        lista.Add(pedido);
                    }
                } // O leitor é fechado aqui
            } // O comando é descartado aqui

            return lista;
        }

        public void Inserir(Pedido pedido)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO pedido VALUES (@_nome, @_status, @_forma_pagamento, @_numero, @_total)");

                comando.Parameters.AddWithValue("@_nome", pedido.NomeCliente);
                comando.Parameters.AddWithValue("@_status", pedido.Status); 
                comando.Parameters.AddWithValue("@_forma_pagamento", pedido.FormaPagamento);
                comando.Parameters.AddWithValue("@_numero", pedido.NumeroPedido);
                comando.Parameters.AddWithValue("@_total", pedido.Total);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

        }

       
    }
}
