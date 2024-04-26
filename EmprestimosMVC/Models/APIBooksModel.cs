using System.ComponentModel.DataAnnotations;

namespace EmprestimosMVC.Models
{
    public class APIBooksListModel
    {
        public List<APIBooksModel> Livros { get; set; }
    }

    public class APIBooksModel
    {
        public string Titulo { get; set; }
        public string Autores { get; set; }
    }
}
