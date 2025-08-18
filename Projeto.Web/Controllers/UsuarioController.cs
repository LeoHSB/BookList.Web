using Projeto.Web.Models;
using System;
using System.Web.Mvc;
using Projeto.Data.Entities;
using Projeto.Data.Persistence;
using Projeto.Util;
using System.Linq;
using System.Web.Security;
namespace Projeto.Web.Controllers
{
    [AllowAnonymous]
    public class UsuarioController : Controller
    {
        public ActionResult Cadastro()
        {
            return View(); 
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AutenticarUsuario(UsuarioModelLogin model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UsuarioData d = new UsuarioData(); 
                    Usuario u = d.Authenticate(model.Login,
                    Criptografia.GetMD5Hash(model.Senha));
                    if (u != null) 
                    {
                        FormsAuthentication.SetAuthCookie(u.Email, false);

                        Session.Add("usuariologado", u);
                        return RedirectToAction("Index", "Biblioteca");
                    }
                    else 
                    {
                        ViewBag.Mensagem = "Acesso Negado.";
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }
            return View("Login"); 
        }

        [HttpPost]
        public ActionResult CadastrarUsuario(UsuarioModelCadastro model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Usuario u = new Usuario() 
                    {
                        Nome = model.Nome,
                        Email = model.Email,
                        Senha = Criptografia.GetMD5Hash(model.Senha),
                        DataCadastro = DateTime.Now
                    };
                    UsuarioData d = new UsuarioData();
                    d.Insert(u); 
                    ViewBag.Mensagem = "Usuario " + u.Nome + ", cadastrado com sucesso.";
                    ModelState.Clear(); 
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }
            return View("Cadastro"); 
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Remove("usuariologado");
            Session.Abandon();
            return View("Login");
        }
    }
}