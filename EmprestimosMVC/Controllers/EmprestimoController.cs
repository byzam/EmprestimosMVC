using EmprestimosMVC.Data;
using EmprestimosMVC.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
