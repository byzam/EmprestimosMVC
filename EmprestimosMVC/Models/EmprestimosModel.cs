﻿using System.ComponentModel.DataAnnotations;

namespace EmprestimosMVC.Models
{
    public class EmprestimosModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Digite o nome do Recebedor.")]
        public string Recebedor { get; set; }

        [Required(ErrorMessage = "Digite o nome do Fornecedor.")]
        public string Fornecedor { get; set; }

        [Required(ErrorMessage = "Digite o nome do Livro.")]
        public string LivroEmprestado { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }

    }
}
