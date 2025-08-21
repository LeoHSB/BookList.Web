using Projeto.Data.Entities;
using Projeto.Data.Persistence;
using Projeto.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Projeto.Web.Controllers
{
    public class BibliotecaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult ModalCadastroBiblioteca()
        {
            return PartialView("_ModalCadastroBiblioteca", new BibliotecaModelCadastro());
        }

        [HttpPost]
        public JsonResult CadastrarBibliotecaAjax(BibliotecaModelCadastro model)
        {
            var usuario = (Usuario)Session["usuariologado"];
            if (usuario == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Usuário não está logado. Faça login novamente."
                });
            }

            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values.SelectMany(v => v.Errors)
                                             .Select(e => e.ErrorMessage)
                                             .ToList();
                return Json(new
                {
                    success = false,
                    message = "Erro de validação: " + string.Join(", ", erros)
                });
            }

            try
            {
                BibliotecaData bibliotecaData = new BibliotecaData();

                var bibliotecasUsuario = bibliotecaData.BuscarBibliotecasPorId(usuario.Id);
                if (bibliotecasUsuario.Count >= 10)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Você já possui o limite máximo de 10 bibliotecas."
                    });
                }

                Biblioteca biblioteca = new Biblioteca()
                {
                    Nome = model.Nome,
                    Usuario = usuario
                };

                bibliotecaData.Insert(biblioteca);

                return Json(new
                {
                    success = true,
                    message = "Biblioteca '" + biblioteca.Nome + "' cadastrada com sucesso!"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = "Erro ao cadastrar biblioteca: " + ex.Message
                });
            }
        }

        [HttpGet]
        public PartialViewResult ConsultarBibliotecas()
        {
            var usuario = (Usuario)Session["usuariologado"];
            var usuarioId = usuario.Id;

            var bibliotecaData = new BibliotecaData();
            var bibliotecas = bibliotecaData.BuscarBibliotecasPorId(usuarioId);

            var model = bibliotecas.Select(b => new BibliotecaModelConsulta
            {
                Id = b.Id,
                Nome = b.Nome,
                QuantidadeLivros = b.Livro.Count()
            }).ToList();

            return PartialView("_ConsultarBibliotecas",model);
        }

        [HttpGet]
        public ActionResult ExcluirBiblioteca(int id)
        {
            try
            {
                BibliotecaData bd = new BibliotecaData();
                Biblioteca b = bd.Find(id);
                bd.Delete(b);
                ViewBag.Mensagem = "Categoria excluida com sucesso.";
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }
            return View("Index");
        }

    }
}