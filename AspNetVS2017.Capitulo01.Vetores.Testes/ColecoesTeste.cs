using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AspNetVS2017.Capitulo01.Vetores.Testes
{
    [TestClass]
    public class ColecoesTeste
    {

        /// <summary>
        /// Classe Lista
        /// </summary>
        /// 
        [TestMethod]
        public void ListTeste()
        {
            var inteiros = new List<int>(); 
            //Classe necessita de ()
            //pode definir tamanho inicial: List<int>(10);
            //padrão começa com 4 vai dobrando

            inteiros.Add(5);
            inteiros.Add(3);
            inteiros.Add(25);
            inteiros.Add(55);
            //inteiros[10] = 27 / Não funciona

            var maisInteiros = new List<int>(){ 1, 2, 3, 9 };

            //Adiciona uma lista em outra
            inteiros.AddRange(maisInteiros);

            //Adiciona um valor na lista
            //Posicao , Valor (empura o valor anterior para a proxima posição)
            inteiros.Insert(0,32);

            //Remove um valor (não posição)
            //Se a lista tiver mais de um valor igual só remove o 1º
            inteiros.Remove(3);

            //Remove uma posição
            //deve ser posição valida
            inteiros.RemoveAt(1);
            //inteiros.RemoveAll(i => i ==3)

            //Ordena lista
            inteiros.Sort();

            var primeiro = inteiros[0];
            var ultimo = inteiros[inteiros.Count - 1];

            foreach (var inteiro in inteiros)
            {
                Console.WriteLine($"{inteiros.IndexOf(inteiro)}:{inteiro}");
            }
        }

        /// <summary>
        /// Classe Dicionario
        /// O índice do vetor deixa de ser um inteiro e passa ser qualquer coisa
        /// Dictionary<Chave,Valor>()
        /// </summary>
        /// 
        [TestMethod]
        public void DictionaryTeste()
        {
            var feriados = new Dictionary<DateTime,string>();

            feriados.Add(new DateTime(2018,12,25),"Natal");
            feriados.Add(new DateTime(2019, 01, 01), "Ano Novo");
            feriados.Add(new DateTime(2019, 01, 25), "Aniversário de SP");

            var natal = feriados[new DateTime(2018, 12, 25)];

            foreach (var item in feriados)
            {
                //Console.WriteLine($"{item.Key.ToShortDateString()} : {item.Value}");
                Console.WriteLine($"{item.Key.ToString("dd-MM-yyyy")} : {item.Value}");
                // mm = minuto - MM = mês
            }

            Console.WriteLine($"Possui {new DateTime(2018, 12, 25)} ? {feriados.ContainsKey(new DateTime(2018, 12, 25))}");
            Console.WriteLine(feriados.ContainsValue("Aniversário de SP"));
        }

        /// <summary>
        /// Pilha
        /// Last in First out
        /// </summary>
        /// 
        [TestMethod]
        public void StackTeste()
        {
            var pilha = new Stack<int>();

            pilha.Push(1);
            pilha.Push(4);
            pilha.Push(7);

            Assert.AreEqual(pilha.Pop(),7); //POP retira da pilha
            Assert.AreEqual(pilha.Peek(),4); //PEEK verifica sem retirar da pilha

            Console.WriteLine($"A pilha está vazia? {pilha.Count == 0}");
        }

        /// <summary>
        /// Fila
        /// First in First Out
        /// </summary>
        /// 
        [TestMethod]
        public void QueueTeste()
        {
            var fila = new Queue<int>();

            fila.Enqueue(1);
            fila.Enqueue(4);
            fila.Enqueue(2);

            Assert.AreEqual(fila.Dequeue(), 1);
            Assert.AreEqual(fila.Peek(), 4);

            Console.WriteLine($"Fila vazia? {fila.Count == 0}");

        }
    }
}
