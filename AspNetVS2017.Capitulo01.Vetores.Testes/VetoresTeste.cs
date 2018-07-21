using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq; // Linguagem que usa os comandos do SQL no código

namespace AspNetVS2017.Capitulo01.Vetores.Testes
{
    [TestClass]
    public class VetoresTeste
    {
        /// <summary>
        /// Utilando vetores
        ///     Conjunto de dados / Variável com mais de um dado inserido
        /// </summary>
        
        [TestMethod]
        public void InicializacaoTeste()
        {
            //Instanciar o vetor
            string[] strings = new string[10]; //de 0 a 9 //Precisa da palavra new para instanciar vetores
            strings[0] = "Vítor";

            var decimais = new decimal[] { 0.5m, 1, 1.59m }; //Precisa da palavra new para instanciar vetores

            int[] inteiros = { 1, 58, 10, 0 }; //Para este tipo de vetor não precisa, modelo pouco usado

            //For quande sabe o nº de repetições
            //Foreach não sabe/importa quantos itens tem

            foreach (var inteiro in inteiros)
            {
                Console.WriteLine(inteiro);
            }

            Console.WriteLine($"Tamanho do vetor: {inteiros.Length}"); //Length - propriedade

            var soma = inteiros.Where(i => i > 1).Sum();
            Console.WriteLine(soma);
        }


        /// <summary>
        /// Modificando vetores
        /// </summary>

        [TestMethod]
        public void RedimensionamentoTeste()
        {
            var decimais = new decimal[] { 0.5m, 1, 1.59m }; // definido tamanho de 3 posições
            // não usar resize, cria cópia ocupando mais espaço na memória
            // melhor criar vetor maior

            Array.Resize(ref decimais, 5);

            decimais[4] = 2.1m; //inclui o valor na posição 4 do vetor
        }

        /// <summary>
        /// Utilizando a biblioteca Sys.Linq
        /// Utilizando Assert para Prova Unitária
        /// </summary>

        [TestMethod]
        public void OrdenacaoTeste()
        {
            var decimais = new decimal[] { 1, 0.5m, 1.59m, 0.02m }; // definido tamanho de 3 posições
            //Cria um vetor novo copiando os valores ordenados

            Array.Sort(decimais);

            //Só para teste unitario
            //Como não há como verificar se o sort foi feito, 
            //utilizamos o Assert para comparar dados e mostrar como OK ou ERRO a PU
            Assert.AreEqual(decimais[0], 0.02m);
        }

        [TestMethod]
        public void ParamsTeste()
        {
            var decimais = new decimal[] { 1, 0.5m, 1.59m, 0.02m };

            Console.WriteLine(CalcMedia(decimais)); // chama o metodo CalcMedia criado abaixo (linha 78)
            
            //Console.WriteLine(CalcMedia(1, 2, 0.2m, 0.01m)); Não funciona sem o Params (linha 78)

        }

        
        /* Exemplo de um método simples
         * 
         * private decimal CalcMedia(decimal dec1, decimal dec2)
         * {
         *   return (dec1 + dec2)/2;
         * } */

        /* Params só funciona com vetor
         Exemplo:
         private decimal CalcMedia(params decimal[] vals)
           então poderia usar: 
         Console.WriteLine(CalcMedia(1,3.5m,4));
         sem Params somente aceitaria com o nome de um vetor */

        // void não retorna dados
        // sem void precisa usar o return

        private decimal CalcMedia(params decimal[] vals) //usando vetor
        {
            var soma = 0m;

            foreach (var @decimal in vals)
            {
                soma += @decimal;
            }

            return soma/vals.Length;

            // Poderia substituir tudo acima por comando Linq: 
            // return decimais.Average()
        }


        [TestMethod]
        public void TodaStringEhUmVetor()
        {
            var nome = "Vítor";

            foreach (var caractere in nome)
            {
                Console.WriteLine(caractere);
            }

            Assert.AreEqual(nome[0],'V');
        }

    }


}
