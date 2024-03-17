namespace EmprestimosMVC.Models
{
    public class EmprestimosModel
    {
        public int id { get; set; }
        public string Recebedor { get; set; }
        public string Fornecedor { get; set; }
        public string LivroEmprestado { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; } = DateTime.Now;

    }
}
