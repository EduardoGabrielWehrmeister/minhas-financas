using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    interface lClientePessoaFisica
    {
        int Inserir(ClientePessoaFisica clientePessoaFisica);

        bool Apagar(int id);

        bool Atualizar(ClientePessoaFisica clientePessoaFisica);

        ClientePessoaFisica ObterPeloId(int id);

        List<ClientePessoaFisica> ObterTodos(string busca);
    }
}
