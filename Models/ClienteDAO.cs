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

      

    }
}
