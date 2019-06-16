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
    public class ContaPagarRepository : IRepository
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

        public bool Atualizar(ContaPagar contaPagar)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"UPDATE contaspagar SET nome = @NOME, valor = @VALOR, tipo = @TIPO,
descricao = @DESCRICAO, status = @STATUS WHERE id = @ID";
            comando.Parameters.AddWithValue("@NOME", contaPagar.Nome);
            comando.Parameters.AddWithValue("@VALOR", contaPagar.Valor);
            comando.Parameters.AddWithValue("@TIPO", contaPagar.Tipo);
            comando.Parameters.AddWithValue("@DESCRICAO", contaPagar.Descricao);
            comando.Parameters.AddWithValue("@STATUS", contaPagar.Status);
            comando.Parameters.AddWithValue("@ID", contaPagar.Id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public int Inserir(ContaPagar contaPagar)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"INSERT INTO contaspagar(nome, valor, tipo, descricao, status)
OUTPUT INSERTED.ID VALUES(@NOME, @VALOR, @TIPO, @DESCRICAO, @STATUS)";
            comando.Parameters.AddWithValue("@NOME", contaPagar.Nome);
            comando.Parameters.AddWithValue("@VALOR", contaPagar.Valor);
            comando.Parameters.AddWithValue("@TIPO", contaPagar.Tipo);
            comando.Parameters.AddWithValue("@DESCRICAO", contaPagar.Descricao);
            comando.Parameters.AddWithValue("@STATUS", contaPagar.Status);
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
            ContaPagar contaPagar = new ContaPagar();
            contaPagar.Id = Convert.ToInt32(row["id"]);
            contaPagar.Nome = row["nome"].ToString();
            contaPagar.Valor = Convert.ToDecimal(row["valor"]);
            contaPagar.Tipo = row["tipo"].ToString();
            contaPagar.Descricao = row["descricao"].ToString();
            contaPagar.Status = row["status"].ToString();

            return contaPagar;

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

            List<ContaPagar> contasPagar = new List<ContaPagar>();

            for(int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow row = tabela.Rows[i];
                ContaPagar contaPagar = new ContaPagar();
                contaPagar.Id = Convert.ToInt32(row["id"]);
                contaPagar.Nome = row["nome"].ToString();
                contaPagar.Valor = Convert.ToUInt32(row["valor"]);
                contaPagar.Tipo = row["tipo"].ToString();
                contaPagar.Descricao = row["descricao"].ToString();
                contaPagar.Status = row["status"].ToString();
                contasPagar.Add(contaPagar);
            }
            return contasPagar;

        }
    }
}
