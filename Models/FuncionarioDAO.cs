using AppWeb.Configs;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace AppWeb.Models
{
    public class FuncionarioDAO
    {
        private readonly Conexao _conexao;
        public FuncionarioDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Funcionario> listarTodos()
        {
            // ... (Este método está correto) ...
            var lista = new List<Funcionario>();

            var comando = _conexao.CreateCommand("SELECT * FROM funcionarios;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
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
                // CORRIGIDO: O nome da tabela deve ser 'funcionarios'
                // CORRIGIDO: Apenas um 'null' para o 'id_func' (auto_increment), e o resto são parâmetros.
                var comando = _conexao.CreateCommand("INSERT INTO funcionarios VALUES (null, @_nome, @_cargo, @_dataNasc, @_email, @_telefone, @_cpf, @_cep)");

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

        // Dentro da classe public class FuncionarioDAO
        public Funcionario? BuscarPorId(int id)
        {
            var comando = _conexao.CreateCommand("SELECT * FROM funcionarios WHERE id_func = @id;");
            comando.Parameters.AddWithValue("@id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var funcionario = new Funcionario();
                // Mapeamento das colunas (igual ao listarTodos())
                funcionario.Id = leitor.GetInt32("id_func");
                funcionario.Nome = DAOHelper.GetString(leitor, "nome_func");
                funcionario.Cargo = DAOHelper.GetString(leitor, "cargo_func");
                funcionario.DataNasc = DAOHelper.GetString(leitor, "dataNasc_func");
                funcionario.Email = DAOHelper.GetString(leitor, "email_func");
                funcionario.Telefone = DAOHelper.GetString(leitor, "telefone_func");
                funcionario.Cpf = DAOHelper.GetString(leitor, "cpf_func");
                funcionario.Cep = DAOHelper.GetString(leitor, "cep_func");

                leitor.Close(); // Fechar o leitor
                return funcionario;
            }
            else
            {
                leitor.Close(); // Fechar o leitor
                return null;
            }

        }

        // Dentro da classe public class FuncionarioDAO
        public void Atualizar(Funcionario funcionario)
        {
            try
            {
                // SQL: UPDATE na tabela 'funcionarios', setando todos os campos
                var comando = _conexao.CreateCommand(
                    "UPDATE funcionarios SET " +
                    "nome_func = @_nome, " +
                    "cargo_func = @_cargo, " +
                    "dataNasc_func = @_dataNasc, " +
                    "email_func = @_email, " +
                    "telefone_func = @_telefone, " +
                    "cpf_func = @_cpf, " +
                    "cep_func = @_cep " +
                    "WHERE id_func = @_id;"
                );

                // Parâmetros (CRUCIAL: o ID deve ser o último para o WHERE)
                comando.Parameters.AddWithValue("@_nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@_cargo", funcionario.Cargo);
                comando.Parameters.AddWithValue("@_dataNasc", funcionario.DataNasc);
                comando.Parameters.AddWithValue("@_email", funcionario.Email);
                comando.Parameters.AddWithValue("@_telefone", funcionario.Telefone);
                comando.Parameters.AddWithValue("@_cpf", funcionario.Cpf);
                comando.Parameters.AddWithValue("@_cep", funcionario.Cep);
                comando.Parameters.AddWithValue("@_id", funcionario.Id); // ID é usado para o WHERE

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}