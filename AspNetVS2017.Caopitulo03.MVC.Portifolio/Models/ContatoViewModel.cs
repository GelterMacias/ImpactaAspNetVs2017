using System.ComponentModel.DataAnnotations;

namespace AspNetVS2017.Caopitulo03.MVC.Portifolio.Models
{
    public class ContatoViewModel
    {
        [Required] //Preenchimento obrigatório
        public string Nome { get; set; }

        [Required]
        //[RegularExpression()] //Valida padrão preenchido no campo
        [EmailAddress] //Valida padrão preenchido no campo [específico de e-mail]
        public string Email { get; set; }

        [Required]
        public string Mensagem { get; set; }
    }
}