using AppWeb.Configs;
using System.Data;

namespace AppWeb.Models
{
    public class IngredientesDAO
    {
        private readonly Conexao _conexao;
        public IngredientesDAO(Conexao conexao) // serve pra fornecedor também
        {
            _conexao = conexao;
        }

        public List<Ingredientes> listarTodos()
        {
            var lista = new List<Ingredientes>();

            var comando = _conexao.CreateCommand("SELECT * FROM ingredientes;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read()) // enquanto tiver condição, o while vai rodar
            {
                var ingredientes = new Ingredientes();
                ingredientes.Id = leitor.GetInt32("id_ing");
                ingredientes.Nome = DAOHelper.GetString(leitor, "nome_ing");
                ingredientes.Descricao = DAOHelper.GetString(leitor, "descricao_ing");
                ingredientes.Quantidade = leitor.GetInt32("quantidade_ing");

                lista.Add(ingredientes);
            }

            return lista;
        }
        public List<Ingredientes> cadastrarIngrediente()
        {
            var lista = new List<Ingredientes>();

            var comando = _conexao.CreateCommand("SELECT * FROM ingredientes;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read()) // enquanto tiver condição, o while vai rodar
            {
                var ingredientes = new Ingredientes();
                ingredientes.Id = leitor.GetInt32("id_ing");
                ingredientes.Nome = DAOHelper.GetString(leitor, "nome_ing");
                ingredientes.Descricao = DAOHelper.GetString(leitor, "descricao_ing");
                ingredientes.Quantidade = leitor.GetInt32("quantidade_ing");

                lista.Add(ingredientes);
            }

            return lista;
        }

        public void Inserir(Ingredientes ingredientes)
        {
            try
            {
                // Corrigido para especificar as colunas e usar 'null' apenas para o ID (se auto_increment)
                var comando = _conexao.CreateCommand("INSERT INTO ingredientes (nome_ing, descricao_ing, quantidade_ing) VALUES (@_nome, @_descricao, @_qtd)");

                comando.Parameters.AddWithValue("@_nome", ingredientes.Nome);
                comando.Parameters.AddWithValue("@_descricao", ingredientes.Descricao);
                comando.Parameters.AddWithValue("@_qtd", ingredientes.Quantidade);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Ingredientes? BuscarPorId(int id)
        {
            // Corrigido: Usando a coluna id_ing (assumido)
            var comando = _conexao.CreateCommand("SELECT * FROM ingredientes WHERE id_ing = @id;");
            comando.Parameters.AddWithValue("@id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var ingrediente = new Ingredientes();
                ingrediente.Id = leitor.GetInt32("id_ing");
                ingrediente.Nome = DAOHelper.GetString(leitor, "nome_ing");
                ingrediente.Descricao = DAOHelper.GetString(leitor, "descricao_ing");
                ingrediente.Quantidade = leitor.GetInt32("quantidade_ing");

                leitor.Close(); // CRÍTICO: Fechar o leitor após leitura
                return ingrediente;
            }
            else
            {
                leitor.Close(); // CRÍTICO: Fechar o leitor mesmo se não houver leitura
                return null;
            }
        }

        public void Atualizar(Ingredientes ingrediente)
        {
            try
            {
                // Corrigido: Tabela era 'produto', agora é 'ingredientes'
                var comando = _conexao.CreateCommand(
                    "UPDATE ingredientes SET nome_ing = @_nome, descricao_ing = @_descricao, " +
                    "quantidade_ing = @_quantidade WHERE id_ing = @_id;");

                comando.Parameters.AddWithValue("@_nome", ingrediente.Nome);
                comando.Parameters.AddWithValue("@_descricao", ingrediente.Descricao);
                comando.Parameters.AddWithValue("@_quantidade", ingrediente.Quantidade);
                comando.Parameters.AddWithValue("@_id", ingrediente.Id);

                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

    }

}
