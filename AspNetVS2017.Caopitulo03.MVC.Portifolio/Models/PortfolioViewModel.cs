using System.Collections.Generic;

namespace AspNetVS2017.Caopitulo03.MVC.Portifolio.Models
{
    public class PortfolioViewModel
    {
        public List<string> CaminhosImagens { get; set; } = new List<string>();
        //Todo property quando instanciada ganha um valor Default - Lista não ganha nada, precisa de new
        //Porperty tipo lista precisa ser instanciada
    }
}