using ClosedXML.Excel;
using EmprestimosMVC.Data;
using EmprestimosMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EmprestimosMVC.Controllers
{
    public class ExportacaoController : Controller
    {
        readonly private AplicationDbContext _db;

        public ExportacaoController(AplicationDbContext db)
        {
            _db = db;
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

            if (dados.Count > 0)
            {
                dados.ForEach(emprestimo =>
                {
                    dataTable.Rows.Add(emprestimo.Recebedor, emprestimo.Fornecedor, emprestimo.LivroEmprestado, emprestimo.DataUltimaAtualizacao);
                });
            }



            return dataTable;
        }

    }
}
