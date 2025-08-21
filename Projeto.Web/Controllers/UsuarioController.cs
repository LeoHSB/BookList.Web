using Projeto.Data.Entities;
using Projeto.Data.Persistence;
using Projeto.Util;
using Projeto.Web.Models;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
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

        [HttpGet]
        public PartialViewResult CadastroChave()
        {
            return PartialView("_CadastroChave", new ChaveApiCadastroModel());
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

        [HttpPost]
        public JsonResult CadastroChave(ChaveApiCadastroModel model)
        {
            var resultado = new { sucesso = false, mensagem = "" };

            if (ModelState.IsValid)
            {
                try
                {
                    var usuario = (Usuario)Session["usuariologado"];
                    if (usuario == null)
                    {
                        resultado = new { sucesso = false, mensagem = "Usuário não está logado." };
                        return Json(resultado);
                    }

                    string chaveCriptografada = Criptografia.Criptografar(model.ApiKey);

                    string connectionString = ConfigurationManager.ConnectionStrings["banco"].ConnectionString;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = "UPDATE Usuario SET ApiKey = @ApiKey WHERE Id = @Id";

                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@ApiKey", chaveCriptografada);
                            cmd.Parameters.AddWithValue("@Id", usuario.Id);

                            int linhasAfetadas = cmd.ExecuteNonQuery();

                            if (linhasAfetadas > 0)
                            {
                                usuario.ApiKey = chaveCriptografada;
                                Session["usuariologado"] = usuario;

                                resultado = new { sucesso = true, mensagem = "Chave Api " + usuario.Nome + " cadastrada/atualizada com sucesso." };
                            }
                            else
                            {
                                resultado = new { sucesso = false, mensagem = "Usuário não encontrado no banco." };
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    resultado = new { sucesso = false, mensagem = "Erro: " + e.Message };
                }
            }
            else
            {
                resultado = new { sucesso = false, mensagem = "Dados inválidos." };
            }

            return Json(resultado);
        }
    }
}
