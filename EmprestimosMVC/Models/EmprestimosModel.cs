namespace EmprestimosMVC.Models
{
    public class EmprestimosModel
    {
        public int id { get; set; }
        public int Recebedor { get; set; }
        public int Fornecedor { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; } = DateTime.Now;

    }
}
