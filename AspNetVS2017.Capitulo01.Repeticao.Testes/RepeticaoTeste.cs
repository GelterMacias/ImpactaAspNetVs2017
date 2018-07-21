using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AspNetVS2017.Capitulo01.Repeticao.Testes
{
    [TestClass]
    public class RepeticaoTeste
    {
        [TestMethod]
        public void ForAninhadoTest()
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Console.WriteLine($"{i} X {j} = {i*j}");
                }
                Console.WriteLine(new string('-',50));
            }

        }

        [TestMethod]
        public void EstruturaForTeste()
        {
            //Opção de FOR apanas para demostração do que corresponde a cada parte

            var i = 1;
            for (Console.WriteLine("Inicialização"); i <= 3; Console.WriteLine(i))
            {
                i++;
            }

            /*
             for(inicializãção; condição de execução; pós-execução)
             {
                execução
             }
             */
        }

        [TestMethod]
        public void ForApenasComCondicao()
        {
            // Apenas demonstração
            var i = 1;
            for (; i <= 3;)
            {
                Console.WriteLine(i++);
            }
        }

        [TestMethod]
        public void ContinueTeste()
        {
            for (int i = 1; i < 11; i++)
            {
                //Continue não sai do bloco, ignora elemento (execução atual)
                if (i<=5)
                {
                    continue;
                }

                Console.WriteLine(i);
            }
        }

        [TestMethod]
        public void BreakTeste()
        {
            for (int i = 1; i < 11; i++)
            {
                //Break interrompe execução do bloco / estrutura de repetição (loop)
                if (i > 5)
                {
                    break;
                }

                Console.WriteLine(i);
            }
        }
    }
}
