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
  public class LoginController : Controller
  {

    private UsuarioRepositorio _repositorio;
    private static bool _relogar;

    public LoginController()
    {
      _repositorio = new UsuarioRepositorio(Conexao.AbrirSessao());
    }

    public ActionResult Logar(UsuarioRegistro model)
    {
      if (_repositorio.Autenticou(model))
      {
        Session["CPF"] = model.CPF;
        return RedirectToAction("Index", "Curriculo");
      }
      else
      {
        _relogar = true;
        return RedirectToAction("Index", "Login");
      }
    }

    public ActionResult Index()
    {
      if (Session["CPF"] != null)
        return RedirectToAction("Index", "Curriculo");

      if (_relogar)
        ViewBag.ErroLogin = "CPF ou Senha inválido.";

      return View();
    }

    [HttpPost]
    public JsonResult CPFJaCadastrado(UsuarioRegistro model)
    {
      model.CPF = model.CPF.Replace(".", "").Replace("-", "");

      return Json(_repositorio.CPFJaExiste(model) == false);
    }

    public ActionResult Registrar(UsuarioRegistro model)
    {
      if (model.CPF != null)
      {
        model.CPF = model.CPF.Replace(".", "").Replace("-", "");
        _repositorio.Novo(model);
      }

      return RedirectToAction("Index");
    }
  }
}
