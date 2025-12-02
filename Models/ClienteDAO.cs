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

        // --- NOVOS MÉTODOS PARA EDITAR E EXCLUIR ---

        /**
         * Método para buscar um cliente pelo ID (Necessário para a tela de Edição)
         */
        public Cliente? BuscarPorId(int id)
        {
            var cliente = new Cliente();

            using (var comando = _conexao.CreateCommand("SELECT * FROM cliente WHERE id_cli = @_id;"))
            {
                comando.Parameters.AddWithValue("@_id", id);

                using (var leitor = comando.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        cliente.Id = leitor.GetInt32("id_cli");
                        cliente.Nome = DAOHelper.GetString(leitor, "nome_cli");
                        cliente.Telefone = DAOHelper.GetString(leitor, "telefone_cli");
                        cliente.Email = DAOHelper.GetString(leitor, "email_cli");
                        cliente.Cidade = DAOHelper.GetString(leitor, "cidade_cli");
                        cliente.Estado = DAOHelper.GetString(leitor, "estado_cli");
                        return cliente;
                    }
                }
            }
            return null; // Retorna nulo se não encontrar
        }

        /**
         * Método para atualizar as informações de um cliente existente
         */
        public void Atualizar(Cliente cliente)
        {
            try
            {
                string sql = @"
                    UPDATE cliente 
                    SET nome_cli = @_nome, 
                        telefone_cli = @_telefone, 
                        email_cli = @_email, 
                        cidade_cli = @_cidade, 
                        estado_cli = @_estado
                    WHERE id_cli = @_id;";

                using (var comando = _conexao.CreateCommand(sql))
                {
                    comando.Parameters.AddWithValue("@_nome", cliente.Nome);
                    comando.Parameters.AddWithValue("@_telefone", cliente.Telefone);
                    comando.Parameters.AddWithValue("@_email", cliente.Email);
                    comando.Parameters.AddWithValue("@_cidade", cliente.Cidade);
                    comando.Parameters.AddWithValue("@_estado", cliente.Estado);
                    comando.Parameters.AddWithValue("@_id", cliente.Id); // Essencial para o WHERE

                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /**
         * Método para excluir um cliente pelo ID
         */
        public void Excluir(int id)
        {
            try
            {
                using (var comando = _conexao.CreateCommand("DELETE FROM cliente WHERE id_cli = @_id;"))
                {
                    comando.Parameters.AddWithValue("@_id", id);

                    comando.ExecuteNonQuery(); // Executa o comando de exclusão
                }
            }
            catch (Exception)
            {
                // Tratar ou logar o erro, especialmente se houver chaves estrangeiras
                throw;
            }
        }
    }
}




