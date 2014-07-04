using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CurriculoExpressInfra;
using CurriculoExpressData;
using CurriculoExpressDomain;

namespace CurriculoExpressWeb
{
    public class CurriculoController : Controller
    {
        //
        // GET: /Home/

      private CurriculoRepositorio _repositorio;

      public CurriculoController()
      {
        _repositorio = new CurriculoRepositorio(Conexao.AbrirSessao());
      }

        public ActionResult Index()
        {
          if (Session["CPF"] == null)
            return RedirectToAction("Index", "Login");

          return View();
        }

        public ActionResult Acao(string Comando, Curriculo model)
        {
          if ((Comando == "Impressao") || (Comando == "Criar"))
          {
            return RedirectToAction(Comando, model);
          }
          else
            return View("Index");
        }

        public void Limpar()
        {
          ModelState.Clear();
        }


      [HttpPost]
      public JsonResult CPFJaCadastrado(Curriculo model)
      {
        model.CPF = model.CPF.Replace(".", "").Replace("-", "");
        return Json(_repositorio.CPFJaExiste(model) == false);
      }

      [HttpPost]
      public JsonResult IdentidadeJaExiste(Curriculo model)
      {
        model.Identidade = model.Identidade.Replace(".", "").Replace("-", "");
        return Json(_repositorio.CPFJaExiste(model) == false);
      }


      public ActionResult Impressao(Curriculo model)
      {
        if (Session["CPF"] == null)
          RedirectToAction("Index", "Login");

        return View(model);
      }

        public ActionResult Criar(Curriculo model)
        {
          if (Session["CPF"] == null)
            RedirectToAction("Index", "Login");

          model.CPF = model.CPF.Replace(".", "").Replace("-", "");
          model.Identidade = model.Identidade.Replace(".", "").Replace("-", "");
          _repositorio.Novo(model);
          return RedirectToAction("Index");

          //using (var session = Conexao.AbrirSessao())
          //{
          //  model.CPF = model.CPF.Replace(".", "").Replace("-", "");
          //  model.Identidade = model.Identidade.Replace(".", "").Replace("-", "");
          //  using (var transaction = session.BeginTransaction())
          //  {
          //    var query = session.QueryOver<Curriculo>().Where(x => x.CPF == model.CPF).Where(x => x.Identidade == model.Identidade);

          //    if (query.List().Count == 0)
          //    {
          //      var Novo = new Curriculo { Nome = model.Nome, CPF = model.CPF, Identidade = model.Identidade, 
          //        OrgaoEmissor = model.OrgaoEmissor, Endereco = model.Endereco, Estado = model.Estado, Cidade = model.Cidade};
          //      session.Save(Novo);
          //      transaction.Commit();
          //      return RedirectToAction("Index");
          //    }
          //    else
          //    {
          //      return RedirectToAction("Index");
          //    }
          //  }
          //}
        } 
    }
}
