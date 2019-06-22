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
    public class EnderecoRepository : IEnderecoRepository
    {
        private Conexao conexao;

        public EnderecoRepository()
        {
            conexao = new Conexao();
        }

        public bool Apagar(int id)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "DELETE FROM enderecos WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            int quantidadeaAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeaAfetada == 1;

        }

        public bool Atualizar(Endereco endereco)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"UPDATE enderecos SET unidade_federerativa = @UNIDADE_FEDERATIVA, cidade = @CIDADE, logradouro = @LOGRADOURO, cep = @CEP, 
numero = @NUMERO, complemento = @COMPLEMENTO WHERE id = @ID";
            comando.Parameters.AddWithValue("@UNIDADE_FEDERATIVA", endereco.UnidadeFederativa);
            comando.Parameters.AddWithValue("@CIDADE", endereco.Logradouro);
            comando.Parameters.AddWithValue("@LOGRADOURO", endereco.Logradouro);
            comando.Parameters.AddWithValue("@CEP", endereco.Cep);
            comando.Parameters.AddWithValue("@NUMERO", endereco.Numero);
            comando.Parameters.AddWithValue("@COMPLEMENTO", endereco.Complemento);
            comando.Parameters.AddWithValue("@ID", endereco.Id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public int Inserir(Endereco endereco)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"INSERT INTO enderecos (unidade_federativa, cidade, logradouro, cep, numero, complemento) OUTPUT INSERTED.ID VALUES(@UNIDADE_FEDERATIVA,
@CIDADE, @LOGRADOURO, @CEP, @NUMERO, @COMPLEMENTO)";
            comando.Parameters.AddWithValue("@UNIDADE_FEDERATIVA", endereco.UnidadeFederativa);
            comando.Parameters.AddWithValue("@CIDADE", endereco.Cidade);
            comando.Parameters.AddWithValue("@LOGRADOURO", endereco.Logradouro);
            comando.Parameters.AddWithValue("@CEP", endereco.Cep);
            comando.Parameters.AddWithValue("@NUMERO", endereco.Numero);
            comando.Parameters.AddWithValue("@COMPLEMENTO", endereco.Complemento);
            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();
            return id;
        }

        public Endereco ObterPeloId(int id)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "SELECT * FROM enderecos WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            if (tabela.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = tabela.Rows[0];
            Endereco endereco = new Endereco();
            endereco.Logradouro = row["logradouro"].ToString();
            endereco.Numero = Convert.ToInt32(row["numero"]);
            endereco.Complemento = row["complemento"].ToString();
            endereco.UnidadeFederativa = row["unidade_federeratica"].ToString();
            endereco.Cidade = row["cidade"].ToString();
            endereco.Cep = row["cep"].ToString();
            endereco.Id = Convert.ToInt32(row["id"]);
            return endereco;
        }

        public List<Endereco> ObterTodos(string busca)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"SELECT * FROM enderecos WHERE cidade LIKE @CIDADE";
            busca = $"%{busca}%";
            comando.Parameters.AddWithValue("@CIDADE", busca);
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            List<Endereco> enderecos = new List<Endereco>();

            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow row = tabela.Rows[i];
                Endereco endereco = new Endereco();
                endereco.Cep = row["cep"].ToString();
                endereco.Complemento = row["complemento"].ToString();
                endereco.UnidadeFederativa = row["unidade_federativa"].ToString();
                endereco.Numero = Convert.ToInt32(row["numero"]);
                endereco.Cidade = row["cidade"].ToString();
                endereco.Logradouro = row["logradouro"].ToString();
                endereco.Id = Convert.ToInt32(row["id"]);
                enderecos.Add(endereco);
            }
            return enderecos;
        }
    }
}






