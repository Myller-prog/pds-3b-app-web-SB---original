using AppWeb.Configs;

namespace AppWeb.Models
{
    public class ClienteDAO
    {
        private readonly Conexao _conexao;
        public ClienteDAO(Conexao conexao)
        {
            _conexao = conexao;
        }


        public List<Cliente> listarTodos()
        {
            var lista = new List<Cliente>();

            var comando = _conexao.CreateCommand("SELECT * FROM cliente;");
            var leitor = comando.ExecuteReader();


            while (leitor.Read())
            {
                var cliente = new Cliente();
                cliente.Id = leitor.GetInt32("id_cli");
                cliente.Nome = DAOHelper.GetString(leitor, "nome_cli");
                cliente.Telefone = DAOHelper.GetString(leitor, "telefone_cli");
                cliente.Email = DAOHelper.GetString(leitor, "email_cli");
                cliente.Cidade = DAOHelper.GetString(leitor, "cidade_cli");
                cliente.Estado = DAOHelper.GetString(leitor, "estado_cli");

                lista.Add(cliente);
            }

            return lista;
        }

        public void Inserir(Cliente cliente)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO cliente VALUES (@_nome, @_telefone, @_email, @_cidade, @_estado)");

                comando.Parameters.AddWithValue("@_nome", cliente.Nome);
                comando.Parameters.AddWithValue("@_telefone", cliente.Telefone);
                comando.Parameters.AddWithValue("@_email", cliente.Email);
                comando.Parameters.AddWithValue("@_cidade", cliente.Cidade);
                comando.Parameters.AddWithValue("@_estado", cliente.Estado);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
