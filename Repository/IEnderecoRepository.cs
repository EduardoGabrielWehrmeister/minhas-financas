using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    interface IEnderecoRepository
    {
        int Inserir(Endereco endereco);

        bool Apagar(int id);

        bool Atualizar(Endereco endereco);

        Endereco ObterPeloId(int id);

        List<Endereco> ObterTodos(string busca);
    }
}
