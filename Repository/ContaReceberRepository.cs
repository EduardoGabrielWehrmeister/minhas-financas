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
    public class ContaReceberRepository : JRepository
    {
        private Conexao conexao;

        public ContaReceberRepository()
        {
            conexao = new Conexao();
        }

        public bool Apagar(int id)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "DELETE FROM contasreceber WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;

        }

        public bool Atualizar(ContaReceber contaReceber)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"UPDATE contasreceber SET nome = @NOME, valor = @VALOR, tipo = @TIPO, descricao = @DESCRICAO, status = @STATUS WHERE id = @ID";
            comando.Parameters.AddWithValue("@NOME", contaReceber.Nome);
            comando.Parameters.AddWithValue("@VALOR", contaReceber.Valor);
            comando.Parameters.AddWithValue("@TIPO", contaReceber.Tipo);
            comando.Parameters.AddWithValue("@DESCRICAO", contaReceber.Descricao);
            comando.Parameters.AddWithValue("@STATUS", contaReceber.Status);
            comando.Parameters.AddWithValue("@ID", contaReceber.Id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public int Inserir(ContaReceber contaReceber)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"INSERT INTO contasreceber(nome, valor, tipo, descricao, status) 
OUTPUT INSERTED.ID VALUES(@NOME, @VALOR, @TIPO, @DESCRICAO, @STATUS)";
            comando.Parameters.AddWithValue("@NOME", contaReceber.Nome);
            comando.Parameters.AddWithValue("@VALOR", contaReceber.Valor);
            comando.Parameters.AddWithValue("@TIPO", contaReceber.Tipo);
            comando.Parameters.AddWithValue("@DESCRICAO", contaReceber.Descricao);
            comando.Parameters.AddWithValue("@STATUS", contaReceber.Status);
            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();
            return id;

        }

        public ContaReceber ObterPeloId(int id)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "SELECT * FROM contasreceber WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            if(tabela.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = tabela.Rows[0];
            ContaReceber contaReceber = new ContaReceber();
            contaReceber.Id = Convert.ToInt32(row["id"]);
            contaReceber.Nome = row["nome"].ToString();
            contaReceber.Valor = Convert.ToDecimal(row["valor"]);
            contaReceber.Tipo = row["tipo"].ToString();
            contaReceber.Descricao = row["descricao"].ToString();
            contaReceber.Status = row["status"].ToString();
            return contaReceber;
        }

        public List<ContaReceber> ObterTodos(string busca)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "SELECT nome FROM contasreceber WHERE nome LIKE @NOME";
            busca = $"%{busca}%";
            comando.Parameters.AddWithValue("@NOME", busca);

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            List<ContaReceber> contasReceber = new List<ContaReceber>();

            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow row = tabela.Rows[i];
                ContaReceber contaReceber = new ContaReceber();
                contaReceber.Id = Convert.ToInt32(row["id"]);
                contaReceber.Nome = row["nome"].ToString();
                contaReceber.Valor = Convert.ToDecimal(row["valor"]);
                contaReceber.Tipo = row["tipo"].ToString();
                contaReceber.Descricao = row["descricao"].ToString();
                contaReceber.Status = row["status"].ToString();
                contasReceber.Add(contaReceber);
            }
            return contasReceber;
        }
    }
}
