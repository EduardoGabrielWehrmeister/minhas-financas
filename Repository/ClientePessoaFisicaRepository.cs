using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class ClientePessoaFisicaRepository : lClientePessoaFisica
    {
        private Conexao conexao;

        public ClientePessoaFisicaRepository()
        {
            conexao = new Conexao();
        }

        public int Inserir(ClientePessoaFisica clientePessoaFisica)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"INSERT INTO pessoas_fisicas (nome, cpf, data_nascimento, rg, sexo) OUTPUT INSERTED.ID VALUES (@NOME, @CPF, @DATA_NASCIMENTO, @RG, @SEXO)";
            comando.Parameters.AddWithValue("@NOME", clientePessoaFisica.Nome);
            comando.Parameters.AddWithValue("@CPF", clientePessoaFisica.Cpf);
            comando.Parameters.AddWithValue("@DATA_NASCIMENTO", clientePessoaFisica.DataNascimento);
            comando.Parameters.AddWithValue("@RG", clientePessoaFisica.Rg);
            comando.Parameters.AddWithValue("@SEXO", clientePessoaFisica.Sexo);
            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();
            return id;
        }

        public bool Apagar(int id)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "DELETE FROM pessoas_fisicas WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;

        }

        public bool Atualizar(ClientePessoaFisica clientePessoaFisica)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"UPDATE pessoas_fisicas SET nome = @NOME, cpf= @CPF, data_nascimento = @DATA_NASCIMENTO, rg = @RG, sexo = @SEXO WHERE id = @ID";
            comando.Parameters.AddWithValue("@NOME", clientePessoaFisica.Nome);
            comando.Parameters.AddWithValue("@CPF", clientePessoaFisica.Cpf);
            comando.Parameters.AddWithValue("@DATA_NASCIMENTO", clientePessoaFisica.DataNascimento);
            comando.Parameters.AddWithValue("@RG", clientePessoaFisica.Rg);
            comando.Parameters.AddWithValue("@SEXO", clientePessoaFisica.Sexo);
            comando.Parameters.AddWithValue("@ID", clientePessoaFisica.Id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;

        }

        public ClientePessoaFisica ObterPeloId(int id)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "SELECT * FROM pessoas_fisicas WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            if (tabela.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = tabela.Rows[0];
            ClientePessoaFisica clientePessoaFisica = new ClientePessoaFisica();
            clientePessoaFisica.Id = Convert.ToInt32(row["id"]);
            clientePessoaFisica.Nome = row["nome"].ToString();
            clientePessoaFisica.Cpf = row["cpf"].ToString();
            clientePessoaFisica.DataNascimento = Convert.ToDateTime(row["data_nascimento"]);
            clientePessoaFisica.Rg = row["rg"].ToString();
            clientePessoaFisica.Sexo = row["sexo"].ToString();

            return clientePessoaFisica;

        }

        public List<ClientePessoaFisica> ObterTodos(string busca)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "SELECT * FROM pessoas_fisicas WHERE nome LIKE @NOME";
            busca = $"%{busca}";
            comando.Parameters.AddWithValue("@NOME", busca);

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            List<ClientePessoaFisica> clientePessoasFisicas = new List<ClientePessoaFisica>();

            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow row = tabela.Rows[i];
                ClientePessoaFisica clientePessoaFisica = new ClientePessoaFisica();
                clientePessoaFisica.Nome = row["nome"].ToString();
                clientePessoaFisica.Id = Convert.ToInt32(row["id"]);
                clientePessoaFisica.Cpf = row["cpf"].ToString();
                clientePessoaFisica.DataNascimento = Convert.ToDateTime(row["data_nascimento"]);
                clientePessoaFisica.Rg = row["rg"].ToString();
                clientePessoaFisica.Sexo = row["sexo"].ToString();
                clientePessoasFisicas.Add(clientePessoaFisica);
            }
            return clientePessoasFisicas;
        }
    }
}
