using ClosedXML.Excel;
using EmprestimosMVC.Data;
using EmprestimosMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EmprestimosMVC.Controllers
{
    public class EmprestimoController : Controller
    {

        readonly private AplicationDbContext _db;

        public EmprestimoController(AplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<EmprestimosModel> emprestimos = _db.Emprestimos;
            return View(emprestimos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.id == id);

            if(emprestimo== null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpGet]
        public IActionResult Exportar(int? id)
        {
            var dados = GetDados();

            using (XLWorkbook workbook = new XLWorkbook())
            {
                workbook.AddWorksheet(dados, "Dados Empréstimos");

                using (MemoryStream ms = new MemoryStream())
                {
                    workbook.SaveAs(ms);
                    return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreedsheetml.sheet", "Empréstimo");
                }

            }
        }

        private DataTable GetDados()
        {
            DataTable dataTable = new DataTable();

            dataTable.TableName = "Dados Empréstimos";
            dataTable.Columns.Add("Recebedor", typeof(string));
            dataTable.Columns.Add("Fornecedor", typeof(string));
            dataTable.Columns.Add("Livro", typeof(string));
            dataTable.Columns.Add("Data de Empréstimo", typeof(DateTime));

            var dados = _db.Emprestimos.ToList();
            
            if(dados.Count > 0)
            {
                dados.ForEach(emprestimo =>
                {
                    dataTable.Rows.Add(emprestimo.Recebedor, emprestimo.Fornecedor, emprestimo.LivroEmprestado, emprestimo.DataUltimaAtualizacao);
                });
            }



            return dataTable;
        }

        [HttpPost]
        public IActionResult Cadastrar(EmprestimosModel emprestimos)
        {
            if(ModelState.IsValid)
            {
                emprestimos.DataUltimaAtualizacao = DateTime.Now;

                _db.Emprestimos.Add(emprestimos);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Erro fatal";

            return View();

        }

        [HttpPost]
        public IActionResult Editar(EmprestimosModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                var emprestimoDB = _db.Emprestimos.Find(emprestimo.id);

                emprestimoDB.Fornecedor = emprestimo.Fornecedor;
                emprestimoDB.Recebedor = emprestimo.Recebedor;
                emprestimoDB.LivroEmprestado = emprestimo.LivroEmprestado;

                _db.Emprestimos.Update(emprestimoDB);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Edição realizado com sucesso!";

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Erro fatal";

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Excluir(EmprestimosModel emprestimo)
        {

            if (emprestimo == null)
            {
                return NotFound();
            }

            _db.Emprestimos.Remove(emprestimo);
            _db.SaveChanges();

            TempData["MensagemSucesso"] = "Remoção realizada com sucesso!";

            return RedirectToAction("Index");
        }

    }
}
