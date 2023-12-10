using EmprestimosMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EmprestimosMVC.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }

        public DbSet<EmprestimosModel> Emprestimos { get; set; }

    }
}
