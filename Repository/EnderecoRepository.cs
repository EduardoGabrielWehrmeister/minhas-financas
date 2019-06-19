using System;
using System.Collections.Generic;
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
            comando.Parameters.AddWithValue("@UNIDAED", endereco.)
            comando.Connection.Close();
        }

        public int Inserir(Endereco endereco)
        {
            SqlCommand comando = conexao.Conectar();
        }

        public Endereco ObterPeloId(int id)
        {
        }

        public List<Endereco> ObterTodos(string busca)
        {
        }
    }
}
