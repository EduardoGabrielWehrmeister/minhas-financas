using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class EnderecoController : Controller
    {
        // GET: Endereco
        public ActionResult Index(string pesquisa)
        {
            EnderecoRepository repository = new EnderecoRepository();
            List<Endereco> enderecos = repository.ObterTodos(pesquisa);
            ViewBag.Enderecos = enderecos;
            return View();
        }

        public  ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Apagar(int id)
        {
            EnderecoRepository repository = new EnderecoRepository();
            repository.Apagar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id, string unidadeFederativa, string cidade, string logradouro, string cep, int numero, string complemento)
        {
            Endereco endereco = new Endereco();
            endereco.Id = id;
            endereco.Cep = cep;
            endereco.Cidade = cidade;
            endereco.Complemento = complemento;
            endereco.UnidadeFederativa = unidadeFederativa;
            endereco.Logradouro = logradouro;
            endereco.Numero = numero;
            EnderecoRepository repository = new EnderecoRepository();
            repository.Atualizar(endereco);
            return RedirectToAction("Index");
        }

        public ActionResult Store(string unidadeFederativa, string cidade, string logradouro, string cep, int numero, string complemento)
        {
            Endereco endereco = new Endereco();
            endereco.Cep = cep;
            endereco.Cidade = cidade;
            endereco.Complemento = complemento;
            endereco.UnidadeFederativa = unidadeFederativa;
            endereco.Logradouro = logradouro;
            endereco.Numero = numero;

            EnderecoRepository repository = new EnderecoRepository();
            repository.Inserir(endereco);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            EnderecoRepository repository = new EnderecoRepository();
            Endereco endereco = repository.ObterPeloId(id);
            ViewBag.Endereco = endereco;
            return View();
        }
    }                              
}                                  
                                   
                                  
                                   
                                   