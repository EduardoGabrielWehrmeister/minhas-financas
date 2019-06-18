using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    interface IContaReceberRepository
    {
        int Inserir(ContaReceber contaReceber);

        bool Atualizar(ContaReceber contaReceber);

        bool Apagar(int id);

        ContaReceber ObterPeloId(int id);

        List<ContaReceber> ObterTodos(string busca);
    }
}
