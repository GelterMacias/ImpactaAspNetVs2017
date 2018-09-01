using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pessoal.Dominio;
using Pessoal.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pessoal.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class TarefaRepositorioTests
    {
        private TarefaRepositorio _tarefaRepositorio = new TarefaRepositorio();

        [TestMethod()]
        public void InserirTest()
        {
            var tarefa = new Tarefa();

            tarefa.Nome = "Fechamento";
            tarefa.Prioridade = Prioridade.Alta; //Enum
            tarefa.Concluida = false;
            tarefa.Observacoes = "BW Com";

            tarefa.Id = _tarefaRepositorio.Inserir(tarefa);

            Assert.AreNotEqual(tarefa.Id, 0);
        }

        [TestMethod()]
        public void AtualizarTest()
        {
            //var tarefa = _tarefaRepositorio.Selecionar().First();
            var tarefa = _tarefaRepositorio.Selecionar()[1]; //Posição, não ID

            tarefa.Nome = "Fechamento";
            tarefa.Observacoes = "BW Com";
            tarefa.Concluida = false;
            tarefa.Prioridade = Prioridade.Alta;

            _tarefaRepositorio.Atualizar(tarefa);
        }

        [TestMethod()]
        public void ExcluirTest()
        {
            _tarefaRepositorio.Excluir(1);

            var tarefa = _tarefaRepositorio.Selecionar(1);

            Assert.IsNull(tarefa);
        }
    }
}