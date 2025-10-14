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
                var comando = _conexao.CreateCommand("INSERT INTO ingredientes VALUES (null, null, @_nome, @_descricao, @qtd)");

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

    }

}
