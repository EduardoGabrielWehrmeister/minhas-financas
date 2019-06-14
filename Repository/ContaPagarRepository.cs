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
    class ContaPagarRepository : IRepository
    {
        private Conexao conexao;

        public ContaPagarRepository()
        {
            conexao = new Conexao();
        }

        public bool Apagar(int id)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "DELETE FROM contaspagar WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public bool Atualizar(ContaPagar contapagar)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"UPDATE contaspagar SET nome = @NOME, valor = @VALOR, tipo = @TIPO,
descricao = @DESCRICAO, status = @STATUS WHERE id = @ID";
            comando.Parameters.AddWithValue("@NOME", contapagar.Nome);
            comando.Parameters.AddWithValue("@VALOR", contapagar.Valor);
            comando.Parameters.AddWithValue("@TIPO", contapagar.Tipo);
            comando.Parameters.AddWithValue("@DESCRICAO", contapagar.Descricao);
            comando.Parameters.AddWithValue("@STATUS", contapagar.Status);
            comando.Parameters.AddWithValue("@ID", contapagar.Id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public int Inserir(ContaPagar contapagar)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"INSERT INTO contaspagar (nome, valor, tipo, descricao, status)
OUTPUT INSERTED.ID VALUES (@NOME, @VALOR, @TIPO, @DESCRICAO, @STATUS)";
            comando.Parameters.AddWithValue("@NOME", contapagar.Nome);
            comando.Parameters.AddWithValue("@VALOR", contapagar.Valor);
            comando.Parameters.AddWithValue("@TIPO", contapagar.Tipo);
            comando.Parameters.AddWithValue("@DESCRICAO", contapagar.Descricao);
            comando.Parameters.AddWithValue("@STATUS", contapagar.Status);
            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();
            return id; 
        }

        public ContaPagar ObterPeloId(int id)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "SELECT * FROM contaspagar WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            if(tabela.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = tabela.Rows[0];
            ContaPagar contapagar = new ContaPagar();
            contapagar.Id = Convert.ToInt32(row["id"]);
            contapagar.Nome = row["nome"].ToString();
            contapagar.Valor = Convert.ToDecimal(row["valor"]);
            contapagar.Tipo = row["tipo"].ToString();
            contapagar.Descricao = row["descricao"].ToString();
            contapagar.Status = row["status"].ToString();

            return contapagar;

        }

        public List<ContaPagar> ObterTodos(string busca)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "SELECT * FROM contaspagar WHERE nome LIKE @NOME";
            busca = $"%{busca}%";
            comando.Parameters.AddWithValue("@NOME", busca);

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            List<ContaPagar> contaspagar = new List<ContaPagar>();

            for(int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow row = tabela.Rows[i];
                ContaPagar contapagar = new ContaPagar();
                contapagar.Id = Convert.ToInt32(row["id"]);
                contapagar.Nome = row["nome"].ToString();
                contapagar.Valor = Convert.ToUInt32(row["valor"]);
                contapagar.Tipo = row["tipo"].ToString();
                contapagar.Descricao = row["descricao"].ToString();
                contapagar.Status = row["status"].ToString();
                contaspagar.Add(contapagar);
            }
            return contaspagar;

        }
    }
}
