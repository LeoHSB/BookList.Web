using Projeto.Data.Entities;
using Projeto.Data.Persistence;
using Projeto.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Projeto.Web.Controllers
{
    public class BibliotecaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CadastrarBibliotecaAjax(BibliotecaModelCadastro model)
        {
            if (Session["usuariologado"] == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Usuário não está logado. Faça login novamente."
                });
            }

            if (!ModelState.IsValid)
            {
                var erros = new List<string>();
                foreach (var modelError in ModelState.Values)
                {
                    foreach (var error in modelError.Errors)
                    {
                        erros.Add(error.ErrorMessage);
                    }
                }
                return Json(new
                {
                    success = false,
                    message = "Erro de validação: " + string.Join(", ", erros)
                });
            }

            try
            {
                Biblioteca biblioteca = new Biblioteca()
                {
                    Nome = model.Nome,
                    Usuario = (Usuario)Session["usuariologado"]
                };

                BibliotecaData bibliotecaData = new BibliotecaData();
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
        public PartialViewResult ModalCadastroBiblioteca()
        {
            return PartialView("_ModalCadastroBiblioteca", new BibliotecaModelCadastro());
        }

    }
}