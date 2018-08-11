using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Text;
using System.Web;

namespace AspNetVS2017.Capitulo02.Http.Testes
{
    [TestClass]
    public class HttpTeste
    {
        [TestMethod]
        public void RequestGetTeste()
        {
            /*
             * C - Post 
             * R - Get
             * U - Put
             * D - Delete
             */

            //HttpWebRequest - Cast
            var request = (HttpWebRequest)WebRequest.Create("http://www.example.com?usuarioId=42&cpf=123456789");
            request.Method = "GET";
            request.UserAgent = "Visual Studio";
            request.Date = DateTime.Now;

            Console.WriteLine(GetRequestToString(request));

            Console.WriteLine(new string('-',100));

            Console.WriteLine("Query string." + request.RequestUri.Query);

            Console.WriteLine(new string('-', 100));

            var response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine(GetResponseToString(response));

        }

        [TestMethod]
        public void RequestPostTest()
        {
            var request = (HttpWebRequest)WebRequest.Create("https://httpbin.org/post");
            request.Method = "POST";

            var dados = "nome=Gelter&cpf=12345678&endereco=R. Rua";

            var bytes = new ASCIIEncoding().GetBytes(HttpUtility.HtmlEncode(dados)); //codifica os caracteres especias

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;

            request.GetRequestStream().Write(bytes,0,bytes.Length);

            Console.WriteLine(GetRequestToString(request,dados));

            Console.WriteLine(new string('-', 100));

            var response = (HttpWebResponse)request.GetResponse(); //Este que é ponto que consome a internet

            Console.WriteLine(GetResponseToString(response));
        }


        private string GetResponseToString(HttpWebResponse response)
        {
            var StatusLine = $"HTTP/{response.ProtocolVersion} {(int)response.StatusCode} {response.StatusDescription}";

            var reader = new StreamReader(response.GetResponseStream());

            return StatusLine + Environment.NewLine + GetHeaders(response.Headers) + Environment.NewLine + reader.ReadToEnd();

        }

        private string GetRequestToString(HttpWebRequest request,string dados = null) //atribuir valor inicial torna o parametro opcional
        {
            var requestLine = $"{request.Method} {request.RequestUri} HTTP/{request.ProtocolVersion}";

            return requestLine + Environment.NewLine + GetHeaders(request.Headers)+Environment.NewLine+dados;
        }

        private string GetHeaders(WebHeaderCollection header)
        {
            var headers = "";

            foreach (var chave in header.AllKeys)
            {
                headers += $"{chave}:{header[chave]}" + Environment.NewLine; //recupera a informação do dicionário
            }

            return headers;
        }
        
    }
}
