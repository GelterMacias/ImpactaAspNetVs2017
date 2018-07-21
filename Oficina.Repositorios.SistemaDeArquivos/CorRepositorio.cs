using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Repositorios.SistemaDeArquivos
{
    public class CorRepositorio
    {
        //Para que o caminho do arquivo texto não fique no código
        //Procura as configurações no arquivo App.Config
        private string _caminhoArquivo = ConfigurationManager.AppSettings["caminhoArquivoCor"];

        public List<Cor> Selecionar()
        {
            var cores = new List<Cor>();

            foreach (var linha in File.ReadAllLines(_caminhoArquivo)) //Classe WebConfig AppConfig
            {
                var cor = new Cor();

                cor.ID = Convert.ToInt32(linha.Substring(0, 5));
                cor.Nome = linha.Substring(5);

                cores.Add(cor);
            }

            return cores;
        }
    }

    // CRUDE = create - read - update - delete
}
