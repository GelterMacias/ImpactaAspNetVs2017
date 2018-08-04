using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Oficina.Repositorios.SistemaDeArquivos
{
    public class CorRepositorio
    {
        //Para que o caminho do arquivo texto não fique no código
        //Procura as configurações no arquivo App.Config
        private string _caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory ,ConfigurationManager.AppSettings["caminhoArquivoCor"]);


        //ToDo: OO - polimorfismo por sobrecarga - Dois metodos Selecionar

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

        //Polimorfismo - aceita dois metodos com o mesmo nome mas parametros de entrada diferente
        
        // Assinatura de método:
        // Publico ou / Paramertro de sair / nome do metodo/ parametro de entrada

        public Cor Selecionar(int corId)
        {
            Cor cor = null;

            foreach (var linha in File.ReadAllLines(_caminhoArquivo))
            {
                //Converter para o mesmo tipo do parametro de entrada para comparar
                var linhaId = Convert.ToInt32(linha.Substring(0, 5));

                if (linhaId == corId)
                {

                    cor = new Cor();
                    cor.ID = linhaId;
                    cor.Nome = linha.Substring(5);
                    //Para interromper o loop do foreach, não precisa continuar a percorrer os registros
                    break;
                }
            }

            return cor;
        }


    }

    // CRUDE = create - read - update - delete
    //new reserva espaço na memória, consome memória
}
