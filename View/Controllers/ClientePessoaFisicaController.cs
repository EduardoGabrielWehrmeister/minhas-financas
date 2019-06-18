using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class ClientePessoaFisicaController : Controller
    {
        // GET: ClientePessoaFisica
        public ActionResult Index(string pesquisa)
        {
            ClientePessoaFisicaRepository repository = new ClientePessoaFisicaRepository();
            List<ClientePessoaFisica> clientePessoaFisicas = repository.ObterTodos(pesquisa);

            ViewBag.ClientePessoaFisica = clientePessoaFisicas;
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Editar(int id)
        {
            ClientePessoaFisicaRepository repository = new ClientePessoaFisicaRepository();
            ClientePessoaFisica clientePessoaFisica = repository.ObterPeloId(id);
            ViewBag.ClientePessoaFisica = clientePessoaFisica;
            return View();

        }

        public ActionResult Store(string nome, string cpf, DateTime DataNascimento, string rg, string sexo)
        {
            ClientePessoaFisica clientePessoaFisica = new ClientePessoaFisica();
            clientePessoaFisica.Nome = nome;
            clientePessoaFisica.Cpf = cpf;
            clientePessoaFisica.DataNascimento = DataNascimento;
            clientePessoaFisica.Rg = rg;
            clientePessoaFisica.Sexo = sexo;

            ClientePessoaFisicaRepository repository = new ClientePessoaFisicaRepository();
            repository.Inserir(clientePessoaFisica);
            return RedirectToAction("Index");

        }

        public ActionResult Update(int id, string nome, string cpf, DateTime DataNascimento, string rg, string sexo)
        {
            ClientePessoaFisica clientePessoaFisica = new ClientePessoaFisica();
            clientePessoaFisica.Nome = nome;
            clientePessoaFisica.Id = id;
            clientePessoaFisica.Cpf = cpf;
            clientePessoaFisica.DataNascimento = DataNascimento;
            clientePessoaFisica.Rg = rg;
            clientePessoaFisica.Sexo = sexo;

            ClientePessoaFisicaRepository repository = new ClientePessoaFisicaRepository();
            repository.Atualizar(clientePessoaFisica);
            return RedirectToAction("Index");

        }

        public ActionResult Apagar(int id)
        {
            ClientePessoaFisicaRepository repository = new ClientePessoaFisicaRepository();
            repository.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}