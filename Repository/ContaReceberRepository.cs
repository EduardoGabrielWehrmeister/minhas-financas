using System;
using System.Collections.Generic;
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
        }

        public int Inserir(ContaReceber contReceber)
        {
        }

        public ContaPagar ObterPeloId(int id)
        {
        }

        public List<ContaReceber> ObterTodos(string busca)
        {
        }
    }
}
