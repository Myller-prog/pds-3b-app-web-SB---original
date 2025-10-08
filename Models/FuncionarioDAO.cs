using AppWeb.Configs;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace AppWeb.Models
{
    public class FuncionarioDAO
    {
        private readonly Conexao _conexao;
        public FuncionarioDAO(Conexao conexao) // serve pra fornecedor também
        {
            _conexao = conexao;
        }

        public List<Funcionario> listarTodos()
        {
            var lista = new List<Funcionario>();

            var comando = _conexao.CreateCommand("SELECT * FROM funcionarios;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read()) // enquanto tiver condição, o while vai rodar
            {
                var funcionario = new Funcionario();
                funcionario.Id = leitor.GetInt32("id_func");
                funcionario.Nome = DAOHelper.GetString(leitor, "nome_func");
                funcionario.Cargo = DAOHelper.GetString(leitor, "cargo_func");
                funcionario.DataNasc = DAOHelper.GetString(leitor, "dataNasc_func");
                funcionario.Email = DAOHelper.GetString(leitor, "email_func");
                funcionario.Telefone = DAOHelper.GetString(leitor, "telefone_func");
                funcionario.Cpf = DAOHelper.GetString(leitor, "cpf_func");
                funcionario.Cep = DAOHelper.GetString(leitor, "cep_func");


                lista.Add(funcionario);
            }

            return lista;
        }

        public void Inserir(Funcionario funcionario)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO funcionario VALUES (null, null, @_nome, @_cargo, @_dataNasc, @_email, @_telefone, @_cpf, @_cep)");

                comando.Parameters.AddWithValue("@_nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@_cargo", funcionario.Cargo);
                comando.Parameters.AddWithValue("@_dataNasc", funcionario.DataNasc);
                comando.Parameters.AddWithValue("@_email", funcionario.Email);
                comando.Parameters.AddWithValue("@_telefone", funcionario.Telefone);
                comando.Parameters.AddWithValue("@_cpf", funcionario.Cpf);
                comando.Parameters.AddWithValue("@_cep", funcionario.Cep);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
