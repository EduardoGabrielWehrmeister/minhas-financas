using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    interface IRepository
    {
        int Inserir(ContaPagar contaPagar);

        bool Atualizar(ContaPagar contaPagar);

        bool Apagar(int id);

        ContaPagar ObterPeloId(int id);

        List<ContaPagar> ObterTodos(string busca);

    }

    interface JRepository
    {
        int Inserir(ContaReceber contaReceber);

        bool Atualizar(ContaReceber contaReceber);

        bool Apagar(int id);

        ContaReceber ObterPeloId(int id);

        List<ContaReceber> ObterTodos(string busca);
    }




}
