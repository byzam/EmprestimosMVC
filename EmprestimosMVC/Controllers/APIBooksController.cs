using EmprestimosMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Raven.Abstractions.Connection;
using System.Net.Http;
using System.Net.Http.Json;

namespace EmprestimosMVC.Controllers
{
    public class APIBooksController : Controller
    {
        private string baseURL = "https://www.googleapis.com/books/v1/volumes?q=";
        private string _Termo = "";

        private readonly IHttpClientFactory _httpClientFactory;
        public APIBooksController(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Pesquisar(string termo)
        {
            var apiBooksListModel = new APIBooksListModel();
            apiBooksListModel.Livros = new List<APIBooksModel>();

            string URLfinal = baseURL + termo;

            if (termo == null || termo == "")
            {
                return View("~/Views/Emprestimo/APIBooks.cshtml", apiBooksListModel);
            }

            var client = _httpClientFactory.CreateClient();

            // Faça a requisição à API de Livros do Google
            HttpResponseMessage response = await client.GetAsync(URLfinal);

            if (response.IsSuccessStatusCode)
            {

                // Leia e processe a resposta da API como uma string JSON
                string jsonContent = await response.Content.ReadAsStringAsync();

                // Parse do JSON para um objeto JToken
                JToken jsonObject = JToken.Parse(jsonContent);

                // Extrair os títulos e os autores dos itens

                foreach (var item in jsonObject["items"])
                {
                    var volumeInfo = item.Value<JObject>("volumeInfo");

                    var livro = new APIBooksModel
                    {
                        Titulo = item["volumeInfo"]["title"].ToString(),
                        Autores = string.Empty // inicialize com uma string vazia
                    };

                    if (volumeInfo["authors"] != null)
                    {
                        livro.Autores = item["volumeInfo"]["authors"].SelectToken("$[0]").ToString();
                    }
                    else
                    {
                        livro.Autores = "Desconhecido";
                    }

                    apiBooksListModel.Livros.Add(livro);
                }
                //!= null ? item["volumeInfo"]["authors"].Select(author => author.ToString()).ToList() : new List<string>()
                //= item["volumeInfo"]["authors"].SelectToken("$[0]").ToString(),
                // Retorne o objeto Livros como JSON
                return View("~/Views/Emprestimo/APIBooks.cshtml", apiBooksListModel);
            }
            else
            {
                // Se ocorrer um erro, retorne uma resposta de erro
                return StatusCode((int)response.StatusCode);
            }

            //return View(baseURL);
        }

        [HttpGet]
        public IActionResult CadastrarAposPesquisa(string livroSelecionado)
        {

            ViewData["livroSelecionado"] = livroSelecionado;

            // Retorne a view "cadastrar"
            return View("~/Views/Emprestimo/Cadastrar.cshtml");
        }


    }
}
