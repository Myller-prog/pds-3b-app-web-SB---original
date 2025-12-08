using AppWeb.Configs;
using System.Collections.Generic; // Garante que List<T> seja reconhecido

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

            // Usando a dependência injetada
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
                // ✅ CORRIGIDO: Removida a coluna 'endereco_cli' (resolve 'Unknown column')
                string sql = @"
                    INSERT INTO cliente (nome_cli, telefone_cli, email_cli, cidade_cli, estado_cli) 
                    VALUES (@_nome, @_telefone, @_email, @_cidade, @_estado)";

                // Usando a dependência injetada
                using var comando = _conexao.CreateCommand(sql);

                // ✅ CORRIGIDO: Adicionamos ?? string.Empty (resolve 'cannot be null')
                comando.Parameters.AddWithValue("@_nome", cliente.Nome ?? string.Empty);
                comando.Parameters.AddWithValue("@_telefone", cliente.Telefone ?? string.Empty);
                comando.Parameters.AddWithValue("@_email", cliente.Email ?? string.Empty);
                comando.Parameters.AddWithValue("@_cidade", cliente.Cidade ?? string.Empty);
                comando.Parameters.AddWithValue("@_estado", cliente.Estado ?? string.Empty);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir cliente: {ex.Message}", ex);
            }
        }

        public Cliente? BuscarPorId(int id)
        {
            var cliente = new Cliente();

            // Usando a dependência injetada
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
            return null;
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

                // Usando a dependência injetada
                using (var comando = _conexao.CreateCommand(sql))
                {
                    // É recomendado usar ?? string.Empty aqui também
                    comando.Parameters.AddWithValue("@_nome", cliente.Nome ?? string.Empty);
                    comando.Parameters.AddWithValue("@_telefone", cliente.Telefone ?? string.Empty);
                    comando.Parameters.AddWithValue("@_email", cliente.Email ?? string.Empty);
                    comando.Parameters.AddWithValue("@_cidade", cliente.Cidade ?? string.Empty);
                    comando.Parameters.AddWithValue("@_estado", cliente.Estado ?? string.Empty);
                    comando.Parameters.AddWithValue("@_id", cliente.Id);

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
                string sql = "DELETE FROM cliente WHERE id_cli = @_id";

                using (var comando = _conexao.CreateCommand(sql))
                {
                    comando.Parameters.AddWithValue("@_id", id);
                    comando.ExecuteNonQuery();
                }
            
            }
            catch (Exception ex)
            {
                // Propaga o erro para que o Blazor possa exibi-lo
                throw new Exception($"Erro ao excluir cliente: {ex.Message}", ex);
            }
        }
    }
}