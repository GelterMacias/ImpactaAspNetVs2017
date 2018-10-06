using Loja.Recursos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loja.MVC.Models
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = nameof(Literal.NomeProdutoLabel),ResourceType = typeof(Literal))]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        [Required]
        public int Estoque { get; set; }

        [Required]
        public string Unidade { get; set; }

        public bool Ativo { get; set; }

        [Display(Name = "Categoria")]
        public string CategoriaNome { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int? CategoriaId { get; set; } //int? é um inteiro que aceita nulo

        public List<SelectListItem> Categorias { get; set; } = new List<SelectListItem>();
    }
}