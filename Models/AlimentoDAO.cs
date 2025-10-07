using AppWeb.Configs;

namespace AppWeb.Models
{
    public class AlimentoDAO
    {
        private readonly Conexao _conexao;
        public AlimentoDAO(Conexao conexao) // serve pra fornecedor também
        {
            _conexao = conexao;
        }

        public List<Alimento> listarTodos()
        {
            var lista = new List<Alimento>();

            var comando = _conexao.CreateCommand("SELECT * FROM alimento;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read()) // enquanto tiver condição, o while vai rodar
            {
                var alimento = new Alimento();
                alimento.Id = leitor.GetInt32("id_ali");
                alimento.Nome = DAOHelper.GetString(leitor, "nome_ali");
                alimento.Tipo = DAOHelper.GetString(leitor, "tipo_ali");
                alimento.Valor = leitor.GetDecimal("valor_ali");
                alimento.Ingredientes = DAOHelper.GetString(leitor, "ingrediente_ali");

                lista.Add(alimento);
            }

            return lista;
        }

        public void Inserir(Alimento alimento)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO alimento VALUES (null, null, @_nome, @_tipo, @_valor, @_ingrediente)");

                comando.Parameters.AddWithValue("@_nome", alimento.Nome);
                comando.Parameters.AddWithValue("@_tipo", alimento.Tipo);
                comando.Parameters.AddWithValue("@_valor", alimento.Valor);
                comando.Parameters.AddWithValue("@_ingrediente", alimento.Ingredientes);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
