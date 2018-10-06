using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Loja.MVC.Helpers
{
    public class CulturaHelper
    {
        private const string LinguagemPadrao = "pt-BR";
        private string linguagemSelecionada = LinguagemPadrao;

        public CulturaHelper()
        {
            DefinirLinguagemPadrao();
            ObterRegionInfo();
        }

        private void ObterRegionInfo()
        {
            var cultura = CultureInfo.CreateSpecificCulture(linguagemSelecionada);
            var regiao = new RegionInfo(cultura.LCID);

            NomeNativo = regiao.NativeName;
            Abreviacao = regiao.TwoLetterISORegionName.ToLower();
        }

        public List<string> LinguagensSuportadas { get; set; } = new List<string> {"pt-BR","en-US","es" };

        internal static CultureInfo ObterCultureInfo()
        {
            var linguagemSelecionada = HttpContext.Current.Request.Cookies["LinguagemSelecionada"]?.Value;

            var linguagem = linguagemSelecionada ?? LinguagemPadrao;

            return CultureInfo.CreateSpecificCulture(linguagem);

        }

        public string NomeNativo { get; set; }
        public string Abreviacao { get; set; }


        private void DefinirLinguagemPadrao()
        {
            var request = HttpContext.Current.Request; //Request.algumacoisa só pode ser usada no controller;

           if (request.Cookies["LinguagemSelecionada"] != null) //LinguagemSelecionada igual da Home Controller
            {
                linguagemSelecionada = request.Cookies["LinguagemSelecionada"].Value;

                return;
            }

            if (request.UserLanguages != null && LinguagensSuportadas.Contains(request.UserLanguages[0]))
            {
                linguagemSelecionada = request.UserLanguages[0];
            }

            var cookie = new HttpCookie("LinguagemSelecionada",linguagemSelecionada);
            cookie.Expires = DateTime.MaxValue;

            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}