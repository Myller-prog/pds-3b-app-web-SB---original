using AppWeb.Configs;
using System.Data;

namespace AppWeb.Models
{
    public class ProdutoDAO
    {
        private readonly Conexao _conexao;
        public ProdutoDAO(Conexao conexao) // serve pra fornecedor também
        {
            _conexao = conexao;
        }

        public List<Produto> listarTodos()
        {
            var lista = new List<Produto>();

            var comando = _conexao.CreateCommand("SELECT * FROM produto;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read()) // enquanto tiver condição, o while vai rodar
            {
                var produto = new Produto();
                produto.Id = leitor.GetInt32("id_pro");
                produto.Nome = DAOHelper.GetString(leitor, "nome_pro");
                produto.Descricao = DAOHelper.GetString(leitor, "descricao_pro");
                produto.Quantidade = leitor.GetInt32("quantidade_pro");
                produto.Valor = leitor.GetDecimal("preco_pro");

                lista.Add(produto);
            }

            return lista;
        }

        public void Inserir(Produto produto)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO produto VALUES (null, null, @_nome, @_descricao, @qtd, @_preco)");

                comando.Parameters.AddWithValue("@_nome", produto.Nome);
                comando.Parameters.AddWithValue("@_descricao", produto.Descricao);
                comando.Parameters.AddWithValue("@_qtd", produto.Quantidade);
                comando.Parameters.AddWithValue("@_preco", produto.Valor);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

        }

    }

}
