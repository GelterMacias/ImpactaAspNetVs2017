using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Oficina.Repositorios.SistemaDeArquivos
{
    public class VeiculoRepositorio
    {

        //Conteúdo do field foi inserido no método construtor porque um field não pode estar "aninhado" dentro do outro
        private string _caminhoArquivo;
        private XDocument _arquivoXml;

        //Metodo Construtor (ctor + tab)
        //Mesmo nome da classe
        public VeiculoRepositorio()
        {
            _caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory ,ConfigurationManager.AppSettings["caminhoArquivoVeiculo"]);
        }

        //Como temos mais de um tipo de veiculo, usamos o tipo como uma lista <T> / T pode ser Motocicleta, Caminhão ou VeiculoPasseio
        public void Inserir<T>(T veiculo) where T:Veiculo //where = desde que T seja um veículo
        {
            _arquivoXml = XDocument.Load(_caminhoArquivo);
            var registro = new StringWriter();
            new XmlSerializer(typeof(T)).Serialize(registro,veiculo);
            _arquivoXml.Root.Add(XElement.Parse(registro.ToString()));
            _arquivoXml.Save(_caminhoArquivo);
        }

    }
}
