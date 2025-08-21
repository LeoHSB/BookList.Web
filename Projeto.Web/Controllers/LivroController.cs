using Newtonsoft.Json;
using Projeto.Data.Entities;
using Projeto.Util;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
namespace Projeto.Web.Controllers
{
    public class LivroController : Controller
    {
        public ActionResult Pesquisa()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PesquisarLivros(string q)
        {
            var usuario = (Usuario)Session["usuariologado"];

            if (usuario == null)
            {
                ViewBag.Resultados = new List<dynamic>();
                ViewBag.Mensagem = "Usuário não está logado.";
                return View("Pesquisa");
            }

            if (string.IsNullOrEmpty(usuario.ApiKey))
            {
                ViewBag.Resultados = new List<dynamic>();
                ViewBag.Mensagem = "Você precisa cadastrar uma Chave de API primeiro.";
                return View("Pesquisa");
            }

            if (string.IsNullOrEmpty(q))
            {
                ViewBag.Resultados = new List<dynamic>();
                ViewBag.Mensagem = "Digite algum termo para pesquisar.";
                return View("Pesquisa");
            }

            try
            {
                string apiKey = Criptografia.Descriptografar(usuario.ApiKey);
                string url = $"https://www.googleapis.com/books/v1/volumes?q={q}&maxResults=9&key={apiKey}";

                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().Result;
                        dynamic dados = JsonConvert.DeserializeObject(json);

                        if (dados.items != null)
                        {
                            ViewBag.Resultados = dados.items;
                            ViewBag.Mensagem = null; 
                        }
                        else
                        {

                            ViewBag.Resultados = new List<dynamic>();
                            ViewBag.Mensagem = "A consulta digitada está incorreta ou a Chave de API está incorreta.";
                        }
                    }
                    else
                    {
                        ViewBag.Resultados = new List<dynamic>();
                        ViewBag.Mensagem = "Erro ao acessar a API do Google Books. Verifique sua Chave de API.";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Resultados = new List<dynamic>();
                ViewBag.Mensagem = "Erro: " + ex.Message;
            }

            return View("Pesquisa");
        }
    }
}