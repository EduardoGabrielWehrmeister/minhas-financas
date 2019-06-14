using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using Repository;
using System.Web.Mvc;

namespace View.Controllers
{
    public class ContaPagarController : Controller
    {
        // GET: ContaPagar
        public ActionResult Index(string pesquisa)
        {
            ContaPagarRepository repository = new ContaPagarRepository();
            List<ContaPagar> contasPagar = repository.ObterTodos(pesquisa);

            ViewBag.ContasPagar = contasPagar;
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Store(string nome, decimal valor, string tipo, string descricao, string status)
        {
            ContaPagar contaPagar = new ContaPagar();
            contaPagar.Nome = nome;
            contaPagar.Valor = valor;
            contaPagar.Tipo = tipo;
            contaPagar.Descricao = descricao;
            contaPagar.Status = status;

            ContaPagarRepository repository = new ContaPagarRepository();
            repository.Inserir(contaPagar);
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            ContaPagarRepository repository = new ContaPagarRepository();
            repository.Apagar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            ContaPagarRepository repository = new ContaPagarRepository();
            ContaPagar contaPagar = repository.ObterPeloId(id);
            ViewBag.ContaPagar = contaPagar;
            return View();
        }

        public ActionResult Update(int id, string nome, decimal valor, string tipo, string descricao, string status)
        {
            ContaPagar contaPagar = new ContaPagar();
            contaPagar.Nome = nome;
            contaPagar.Id = id;
            contaPagar.Valor = valor;
            contaPagar.Tipo = tipo;
            contaPagar.Descricao = descricao;
            contaPagar.Status = status;
            ContaPagarRepository repository = new ContaPagarRepository();
            repository.Atualizar(contaPagar);
            return RedirectToAction("Index");
        }
    }
}





