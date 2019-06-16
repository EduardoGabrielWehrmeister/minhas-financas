using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class ContaReceberController : Controller
    {
        // GET: ContaReceber
        public ActionResult Index(string pesquisa)
        {
            ContaReceberRepository repository = new ContaReceberRepository();
            List<ContaReceber> contasReceber = repository.ObterTodos(pesquisa);

            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Store(string nome, decimal valor, string tipo, string descricao, string status)
        {
            ContaReceber contaReceber = new ContaReceber();
            contaReceber.Nome = nome;
            contaReceber.Valor = valor;
            contaReceber.Tipo = tipo;
            contaReceber.Descricao =  descricao;
            contaReceber.Status = status;

            ContaReceberRepository repository = new ContaReceberRepository();
            repository.Inserir(contaReceber);
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            ContaReceberRepository repository = new ContaReceberRepository();
            repository.Apagar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            ContaReceberRepository repository = new ContaReceberRepository();
            ContaReceber contaReceber = repository.ObterPeloId(id);
            ViewBag.ContaReceber = contaReceber;
            return View();
        }

        public ActionResult Update(int id, string nome, decimal valor, string tipo, string descricao, string status)
        {
            ContaReceber contaReceber = new ContaReceber();
            contaReceber.Nome = nome;
            contaReceber.Id = id;
            contaReceber.Valor = valor;
            contaReceber.Tipo = tipo;
            contaReceber.Descricao = descricao;
            contaReceber.Status = status;
            ContaReceberRepository repository = new ContaReceberRepository();
            repository.Atualizar(contaReceber);
            return RedirectToAction("Index");
        }
    }
}